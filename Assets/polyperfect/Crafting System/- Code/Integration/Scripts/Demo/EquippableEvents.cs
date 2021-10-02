using PolyPerfect.Common;
using UnityEngine.Events;

namespace PolyPerfect.Crafting.Integration.Demo
{
    public class EquippableEvents : PolyMono
    {
        public override string __Usage => "Will receive and forward messages when the slot is equipped or unequipped.";

        public UnityEvent OnEquipped, OnUnequipped;

        public void SendEquipped() => OnEquipped.Invoke();
        public void SendUnequipped() => OnUnequipped.Invoke();
    }
}