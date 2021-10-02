using UnityEngine;

namespace PolyPerfect.Crafting.Integration
{
    /// <summary>
    ///     A standard item with an ID
    /// </summary>
    [CreateAssetMenu(menuName = "PolyPerfect/Items/Base Item Object")]
    public class BaseItemObject : BaseObjectWithID
    {
        public override string __Usage => "A simple implementation of an Item.";
    }
}