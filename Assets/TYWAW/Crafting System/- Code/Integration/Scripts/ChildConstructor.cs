﻿using System;
using System.Collections.Generic;
using PolyPerfect.Common;
using PolyPerfect.Crafting.Framework;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration.UGUI
{
    public class ChildConstructor : PolyMono
    {
        public GameObject Prefab;
        public bool ClearOnConstruct = true;
        public bool BringExistingToFront = true;
        public override string __Usage => "Creates children and invokes a bind on all of them. Destroys all children on construct if ClearOnConstruct is enabled. Optionally brings the existing transforms to the front after construction.";
        readonly List<GameObject> constructed = new List<GameObject>();
        readonly List<Transform> existing = new List<Transform>();

        void Awake()
        {
            for (var i = 0; i < transform.childCount; i++) 
                existing.Add(transform.GetChild(i));
        }

        /// <summary>
        /// Convenience function for a common operation in the pack.
        /// </summary>
        public void ConstructAndInsertItems(IEnumerable<ItemStack> items)
        {
            Construct(items, (entry, stack) =>
            {
                entry.GetComponent<IInsert<ItemStack>>().InsertPossible(stack);
            });
        }
        public void Construct<T>(IEnumerable<T> items, Action<GameObject, T> bind)
        {
            if (ClearOnConstruct)
                ClearConstructed();
            
            foreach (var item in items)
            {
                var go = Instantiate(Prefab, transform);
                constructed.Add(go);
                bind(go, item);
            }

            if (!BringExistingToFront) 
                return;
            
            foreach (var item in existing) 
                item.SetAsLastSibling();
        }

        public void ClearConstructed()
        {
            foreach (var item in constructed)
            {
                Destroy(item);
            }
            constructed.Clear();
        }
    }
}