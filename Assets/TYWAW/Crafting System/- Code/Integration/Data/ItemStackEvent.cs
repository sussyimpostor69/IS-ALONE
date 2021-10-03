using System;
using UnityEngine.Events;

namespace PolyPerfect.Crafting.Integration
{
    [Serializable]
    public class ItemStackEvent : UnityEvent<ItemStack>
    {
    }
}