﻿using System;
using PolyPerfect.Common;
using UnityEngine.Events;

namespace PolyPerfect.Crafting.Integration.UGUI
{
    public class UGUIItemTransferListener : PolyMono
    {
        public override string __Usage => $"Allows for registering with the static {nameof(UGUIItemTransfer)} events from within prefabs.";
        
        
        public ItemStackEvent OnExtracted, OnInserted;
        public UnityEvent OnBeginHold, OnEndHold;
        bool isApplicationQuitting;
        void OnEnable()
        {
            UGUIItemTransfer.Instance.OnExtracted.AddListener(OnExtracted.Invoke);
            UGUIItemTransfer.Instance.OnInserted.AddListener(OnInserted.Invoke);
            UGUIItemTransfer.Instance.OnBeginHold.AddListener(OnBeginHold.Invoke);
            UGUIItemTransfer.Instance.OnEndHold.AddListener(OnEndHold.Invoke);
        }

        void OnDisable()
        {
            if (isApplicationQuitting)
                return;
            UGUIItemTransfer.Instance.OnExtracted.RemoveListener(OnExtracted.Invoke);
            UGUIItemTransfer.Instance.OnInserted.RemoveListener(OnInserted.Invoke);
            UGUIItemTransfer.Instance.OnBeginHold.RemoveListener(OnBeginHold.Invoke);
            UGUIItemTransfer.Instance.OnEndHold.RemoveListener(OnEndHold.Invoke);
        }

        void OnApplicationQuit()
        {
            isApplicationQuitting = true;
        }
    }
}