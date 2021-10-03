using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PolyPerfect.Common;
using PolyPerfect.Crafting.Framework;
using UnityEngine;
using UnityEngine.Profiling;

namespace PolyPerfect.Crafting.Integration
{
    /// <summary>
    ///     A database for storing and accessing item data.
    /// </summary>
    [CreateAssetMenu]
    public class ItemWorld : PolyObject, IReadOnlyDataAccessorLookupWithArg<RuntimeID, RuntimeID>
    {
        public List<BaseObjectWithID> Objects = new List<BaseObjectWithID>();

        readonly List<RuntimeID> categories = new List<RuntimeID>();
        readonly Dictionary<RuntimeID, object> categoryDataLookups = new Dictionary<RuntimeID, object>();
        readonly Dictionary<RuntimeID, HashSet<RuntimeID>> categoryMembershipLookup = new Dictionary<RuntimeID, HashSet<RuntimeID>>();
        readonly List<RuntimeID> items = new List<RuntimeID>();

        public readonly IDictionary<RuntimeID, string> Names = new Dictionary<RuntimeID, string>();

        readonly Dictionary<RuntimeID, SimpleRecipe> recipes = new Dictionary<RuntimeID, SimpleRecipe>();
        public override string __Usage => "Holds objects and all their data for use by other things.";

        public IReadOnlyList<RuntimeID> Items => items;
        public IReadOnlyDictionary<RuntimeID, SimpleRecipe> Recipes => recipes;

        public IReadOnlyList<RuntimeID> Categories => categories;


        protected void Awake()
        {
            Rebuild();
        }

        protected void OnValidate()
        {
            Rebuild();
        }

        public IReadOnlyDictionary<RuntimeID, VALUE> GetReadOnlyAccessor<VALUE>(RuntimeID id)
        {
            if (categoryDataLookups.TryGetValue(id, out var contained))
            {
                var dictionary = contained as Dictionary<RuntimeID, VALUE>;
                if (dictionary == null)
                    throw new ArrayTypeMismatchException($"The collection with ID {Names[id]} was not of the expected type {typeof(VALUE).Name}");
                return new ReadOnlyDictionary<RuntimeID, VALUE>(dictionary);
            }

            Debug.LogError($"No category has the id {id}");
            return null;
        }

        public bool CategoryContains(RuntimeID categoryID, RuntimeID itemID)
        {
            return categoryMembershipLookup[categoryID].Contains(itemID); //GetReadOnlyAccessor<bool>(categoryID).ContainsKey(itemID);
        }

        public void Rebuild()
        {
            Names.Clear();
            items.Clear();
            categories.Clear();
            recipes.Clear();
            categoryDataLookups.Clear();
            categoryMembershipLookup.Clear();
            Profiler.BeginSample(nameof(Rebuild));
            foreach (var elem in Objects.Where(o=>o))
            {
                Names[elem.ID] = elem.name; 
                switch (elem)
                {
                    case BaseItemObject item:
                        items.Add(item.ID);
                        break;
                    case BaseCategoryObject cat:
                    {
                        var hashset = new HashSet<RuntimeID>();
                        hashset.UnionWith(cat.ValidMembers.Select(m => m.ID));
                        categoryMembershipLookup[cat.ID] = hashset;

                        if (elem is BaseCategoryWithData withData)
                        {
                            var dict = withData.ConstructDictionary();
                            categoryDataLookups[cat.ID] = dict;
                        }
                        else
                        {
                            var dict = cat.ValidMembers.ToDictionary<BaseObjectWithID, RuntimeID, bool>(member => member, member => true);
                            categoryDataLookups[cat.ID] = dict;
                        }

                        categories.Add(cat.ID);
                        break;
                    }
                    case BaseRecipeObject rec:
                        recipes.Add(rec.ID,
                            new SimpleRecipe(rec.Ingredients.Select(a => new ItemStack(a.ID, a.Value)), rec.Outputs.Select(a => new ItemStack(a.ID, a.Value))));
                        break;
                }
            }

            Profiler.EndSample();
        }
    }
}