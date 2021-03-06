using System;
using PolyPerfect.Crafting.Framework;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration
{
    
    /// <summary>
    ///     References an item or other asset, and associates with it a quantity. Essentially an ItemStack, but uses direct references.
    /// </summary>
    [Serializable]
    public class ObjectItemStack : IValueAndID<Quantity>
    {
        [SerializeField] BaseObjectWithID item;
        [SerializeField] int count = 1;
        public BaseObjectWithID Object => item;
        public RuntimeID ID => item ? item.ID : default;

        public Quantity Value
        {
            get => count;
            set => count = value;
        }

        public static implicit operator ItemStack(ObjectItemStack that) => new ItemStack(that.ID, that.Value);
    }
}