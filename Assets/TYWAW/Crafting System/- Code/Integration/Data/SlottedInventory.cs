using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PolyPerfect.Crafting.Framework;
using ITEM = PolyPerfect.Crafting.Integration.ItemStack;

namespace PolyPerfect.Crafting.Integration
{
    public class SlottedInventory<SLOT> : IList<ITEM>, IInsert<IEnumerable<ITEM>>,IInsert<ITEM> where SLOT : ISlot<Quantity, ITEM>
    {
        public List<SLOT> Slots { get; } = new List<SLOT>();

        public IEnumerable<ITEM> RemainderIfInserted(IEnumerable<ITEM> toInsert)
        {
            return InventoryOps.RemainderAfterInsertCollection(toInsert, Slots);
        }

        public IEnumerable<ITEM> InsertPossible(IEnumerable<ITEM> toInsert)
        {
            return InventoryOps.InsertPossible(toInsert, Slots);
        }

        public IEnumerator<ITEM> GetEnumerator()
        {
            return Slots.Select(s => s.Peek()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Slots.Select(s => s.Peek()).GetEnumerator();
        }

        public void Add(ITEM item)
        {
            Slots.First(s => s.CanInsertCompletely(item)).InsertCompletely(item);
        }

        public void Clear()
        {
            foreach (var slot in Slots)
                slot.ExtractAll();
        }

        public bool Contains(ITEM item)
        {
            return Slots.Select(s => s.Peek()).Contains(item);
        }

        public void CopyTo(ITEM[] array, int arrayIndex)
        {
            for (var i = 0; i < Slots.Count; i++) array[i + arrayIndex] = Slots[i].Peek();
        }

        public bool Remove(ITEM item)
        {
            foreach (var slot in Slots)
                if (slot.Peek().Equals(item))
                {
                    slot.ExtractAll();
                    return true;
                }

            return false;
        }

        public int Count => Slots.Count;
        public bool IsReadOnly => false;

        public int IndexOf(ITEM item)
        {
            for (var i = 0; i < Slots.Count; i++)
                if (Slots[i].Peek().Equals(item))
                    return i;

            return -1;
        }

        public void Insert(int index, ITEM item)
        {
            while (true)
            {
                if (index >= Slots.Count)
                    throw new ArgumentOutOfRangeException();
                if (Slots[index].Peek().IsDefault())
                {
                    Slots[index].InsertCompletely(item);
                    return;
                }

                var extracted = Slots[index].ExtractAll();
                Slots[index].InsertCompletely(item);
                index += 1;
                item = extracted;
            }
        }

        public void RemoveAt(int index)
        {
            Slots[index].ExtractAll();
        }

        public ITEM this[int index]
        {
            get => Slots[index].Peek();
            set
            {
                Slots[index].ExtractAll();
                Slots[index].InsertCompletely(value);
            }
        }

        public ItemStack RemainderIfInserted(ItemStack toInsert)
        {
            return InventoryOps.RemainderAfterInsertCollection(toInsert.MakeEnumerable(), Slots).FirstOrDefault();
        }

        public ItemStack InsertPossible(ItemStack toInsert)
        {
            return InventoryOps.InsertPossible(toInsert, Slots);
        }
    }
}