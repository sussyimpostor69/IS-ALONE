using System.Collections.Generic;
using System.Linq;
using PolyPerfect.Crafting.Framework;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration
{
    [CreateMenuTitle("Simple")]
    [CreateAssetMenu]
    public class RecipeObject : BaseRecipeObject, IRecipe<QuantityContainer, QuantityContainer>
    {
        [SerializeField] QuantityContainer requirements;
        [SerializeField] QuantityContainer results;
        public override string __Usage => "A basic recipe object. Has a crafting result based on a given number of inputs.";
        public override IEnumerable<ItemStack> Ingredients => requirements.Select(i => new ItemStack(i.ID, i.Value));

        public override IEnumerable<ItemStack> Outputs => results.Select(i => new ItemStack(i.ID, i.Value));

        public QuantityContainer Requirements => requirements;

        public QuantityContainer Output => results;
    }
}