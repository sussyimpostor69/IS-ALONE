using System.Collections.Generic;
using System.Linq;
using PolyPerfect.Common;
using PolyPerfect.Crafting.Framework;
using UnityEngine;
using UnityEngine.XR.WSA;

namespace PolyPerfect.Crafting.Integration.UGUI
{
    public class RecipeDisplay : ItemUserBase
    {
        public override string __Usage => "An easy way of displaying items. They are added as children, and children are cleared if desired.";
        public ChildConstructor RequirementsConstructor;
        public ChildConstructor OutputConstructor;
        public void DisplayRecipe(RuntimeID recipeID)
        {
            Debug.Log("Displaying");
            if (RequirementsConstructor)
            {
                RequirementsConstructor.Construct(World.Recipes[recipeID].Requirements,
                        (go, stack) => go.GetComponent<IInsert<ItemStack>>().InsertPossible(stack));
            }

            if (OutputConstructor)
            {
                OutputConstructor.Construct(World.Recipes[recipeID].Output, 
                        (go, stack) => go.GetComponent<IInsert<ItemStack>>().InsertPossible(stack));
                
            }
        }

        public void ClearChildren()
        {
            if (RequirementsConstructor)
                RequirementsConstructor.ClearConstructed();
            if (OutputConstructor)
                OutputConstructor.ClearConstructed();
        }
    }
}