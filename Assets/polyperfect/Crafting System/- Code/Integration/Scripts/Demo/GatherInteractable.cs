using System.Collections.Generic;
using PolyPerfect.Crafting.Framework;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration.Demo
{
    public class GatherInteractable : BaseInteractable
    {
        public override string __Usage => $"Transfers resources to the inventories of interacting GameObjects.";
        readonly Dictionary<GameObject, TransferOverTime> transferers = new Dictionary<GameObject, TransferOverTime>();
        public ItemStackEvent OnTransferred = new ItemStackEvent();

        public override void BeginInteract(GameObject interactor)
        {
            if (!transferers.ContainsKey(interactor))
            {
                var transferer = gameObject.AddComponent<TransferOverTime>();
                transferer.OnTransfer.AddListener(OnTransferred.Invoke);
                transferer.RemoveAmount = 1;
                transferer.TickDuration = 1;
                transferer.Source = GetComponent<IExtract<Quantity,ItemStack>>();
                transferer.Destination = interactor.GetComponentInChildren<IInsert<ItemStack>>();
                transferers.Add(interactor, transferer);
            }
            base.BeginInteract(interactor);
        }

        public override void EndInteract(GameObject interactor)
        {
            if (!transferers.ContainsKey(interactor))
                return;
            Destroy(transferers[interactor]);
            transferers.Remove(interactor);
            base.EndInteract(interactor);
        }
    }
}