using System;
using System.Collections.Generic;
using System.Linq;
using PolyPerfect.Common;
using PolyPerfect.Crafting.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PolyPerfect.Crafting.Integration.UGUI
{
    [RequireComponent(typeof(Crafter))]
    public class UGUICrafter : ItemUserBase
    {
        [SerializeField] List<RecipeCategoryObject> MadeCategories = new List<RecipeCategoryObject>();
        [SerializeField] ChildSlotsInventory StartingInventory;
        [SerializeField] ChildSlotsInventory StartingOutput;
        [SerializeField] ChildConstructor PossibilitiesConstructor;
        [SerializeField] RecipeDisplay RecipeDisplay;
        [SerializeField] Text RecipeNameText;
        Crafter crafter;
        public override string __Usage => "Easy crafting";
        string startingText;
        void Awake()
        {
            crafter = GetComponent<Crafter>();
            crafter.OnSourceUpdate.AddListener(UpdateCraftables);
            crafter.Source = StartingInventory;
            crafter.Destination = StartingOutput;
            if (RecipeNameText)
                startingText = RecipeNameText.text;
        }

        void OnDisable()
        {
            crafter.Recipe = null;
            if (RecipeNameText)
                RecipeNameText.text = startingText;
        }

        protected new void Start()
        {
            base.Start();
            
            UpdateCraftables();
        }

        IEnumerable<RuntimeID> GetRelevantRecipes()
        {
            var accessors = MadeCategories.Select(c => World.GetReadOnlyAccessor<bool>(c)).ToList();
            return World.Recipes.Keys.Where(r => accessors.Any(a => a.ContainsKey(r)));
        }

        public IEnumerable<RuntimeID> GetCraftableRecipesGivenInventory(BaseItemStackInventory inventory)
        {
            if (inventory == null)
                yield break;

            foreach (var recipeID in GetRelevantRecipes())
            {
                var recipe = World.Recipes[recipeID];
                var craftAmount = crafter.GetMaxCraftAmount(inventory, recipe);
                if (craftAmount > 0)
                    yield return recipeID;
            }
        }

        public void OnRecipeSelected(RuntimeID recipeID)
        {
            Debug.Log("Recipe selected");
            crafter.Recipe = World.Recipes[recipeID];
            if (RecipeNameText)
                RecipeNameText.text = World.Names[recipeID];
            RecipeDisplay.DisplayRecipe(recipeID);
        }

        void UpdateCraftables()
        {
            var craftableRecipesGivenInventory = GetCraftableRecipesGivenInventory(crafter.Source);
            PossibilitiesConstructor.Construct(
                craftableRecipesGivenInventory,
                (go, recipeID) =>
                {
                    var evt = new EventTrigger.TriggerEvent();
                    evt.AddListener(e=>OnRecipeSelected(recipeID));
                    go.AddOrGetComponent<EventTrigger>().triggers.Add(new EventTrigger.Entry(){callback = evt, eventID =  EventTriggerType.PointerClick});
                    go.GetComponent<ChildConstructor>().ConstructAndInsertItems(World.Recipes[recipeID].Output);
                });
        }
        
    }
}