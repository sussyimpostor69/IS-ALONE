﻿using PolyPerfect.Common;
using PolyPerfect.Crafting.Framework;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration
{
    public class ItemGameObjectCreator : PolyMono
    {
        public override string __Usage => $"Lets you spawn objects that can have items inserted.\nThe spawned object should usually have a script that implements {nameof(IInsert<ItemStack>)}, such as an {nameof(ItemSlotComponent)}.\nIf there is an {nameof(ItemSlotComponent)} attached to this GameObject, it will be connected and extracted from automatically.";
        public Transform SpawnAtTransform;
        public GameObject ToSpawn;

        [SerializeField]
        bool AutoAttachToSlot;
        ItemSlotComponent _attachedSlot;

        void Awake()
        {
            if (!SpawnAtTransform)
                SpawnAtTransform = transform;
        }

        void Start()
        {
            if (AutoAttachToSlot && TryGetComponent(out _attachedSlot))
            {
                Debug.Log($"Attached on {_attachedSlot.gameObject.name}");
                _attachedSlot.Changed += HandleAttachedSlotChanged;
            }
        }

        void HandleAttachedSlotChanged()
        {
            if (_attachedSlot.Peek().IsDefault())
                return;
            var pulled = _attachedSlot.ExtractAll();
            SpawnAndInsertItem(pulled);
        }

        public void SpawnAndInsertItem(ItemStack stack)
        {
             var go = Instantiate(ToSpawn,SpawnAtTransform.position,SpawnAtTransform.rotation);
             var attachedSlot = go.GetComponentInChildren<IInsert<ItemStack>>();
             attachedSlot?.InsertPossible(stack);
        }
    }
}