using System;
using PolyPerfect.Common;
using UnityEngine;

namespace PolyPerfect.Crafting.Integration
{
    [DefaultExecutionOrder(-999)]
    public class ItemWorldReference : PolyMono
    {
        public override string __Usage => $"Determines which {nameof(ItemWorld)} is used in the scene.";
        public ItemWorld World;
        static ItemWorldReference instance;


        public static ItemWorldReference Instance
        {
            get
            {
                if (!instance)
                    throw new Exception($"There is no {nameof(ItemWorldReference)} in the scene, or a script is trying to access it before it has been initialized. Please create one in Edit mode.");
                return instance;
            }
        }

        void Awake()
        {
            instance = this;
            World.Rebuild();
        }
    }
}