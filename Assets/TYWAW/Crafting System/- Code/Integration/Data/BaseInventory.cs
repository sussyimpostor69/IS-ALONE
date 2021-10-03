using System.Collections.Generic;
using System.Linq;
using PolyPerfect.Common;
using PolyPerfect.Crafting.Framework;

namespace PolyPerfect.Crafting.Integration
{
    public abstract class BaseInventory : PolyMono
    { 
    }

    public abstract class BaseItemStackInventory : BaseInventory, IInsert<ItemStack>, IInsert<IEnumerable<ItemStack>>,IExtract<IEnumerable<ItemStack>>
    {
        public abstract IEnumerable<ItemStack> RemainderIfInserted(IEnumerable<ItemStack> toInsert);
        public abstract IEnumerable<ItemStack> InsertPossible(IEnumerable<ItemStack> toInsert);
        public abstract ItemStack RemainderIfInserted(ItemStack toInsert);
        public abstract ItemStack InsertPossible(ItemStack toInsert);
        public abstract IEnumerable<ItemStack> GetItems();
        public abstract IEnumerable<ISlot<Quantity, ItemStack>> GetSlots();
        public IEnumerable<ItemStack> Peek() => GetItems();

        public IEnumerable<ItemStack> ExtractAll() => GetSlots().Select(s => s.ExtractAll()).ToList();

        public bool CanExtract() => true;
    }
}