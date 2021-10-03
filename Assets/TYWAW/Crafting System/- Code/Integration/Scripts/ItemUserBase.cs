using PolyPerfect.Common;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration
{
    public abstract class ItemUserBase : PolyMono
    {
        protected ItemWorld World => ItemWorldReference.Instance.World;

        protected void Start()
        {
            if (!World)
                Debug.LogError("No Item World Found. Please ensure there is a ObjectWorldReference component with an attached World in the scene.");
        }
    }
}