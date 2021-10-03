using System.Collections.Generic;
using PolyPerfect.Crafting.Framework;

namespace PolyPerfect.Crafting.Integration
{
    /// <summary>
    ///     Simplest IRecipe implementation.
    /// </summary>
    public class SimpleRecipe : IRecipe<IEnumerable<ItemStack>, IEnumerable<ItemStack>>
    {
        public SimpleRecipe(IEnumerable<ItemStack> requirements, IEnumerable<ItemStack> results)
        {
            Requirements = requirements;
            Output = results;
        }

        public IEnumerable<ItemStack> Requirements { get; }
        public IEnumerable<ItemStack> Output { get; }
    }
}