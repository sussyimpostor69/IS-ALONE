using System;
using PolyPerfect.Common;
using UnityEngine;

namespace PolyPerfect.Crafting.Framework
{
    /// <summary>
    ///     An ID to be used to reference items. Used to look up functionality and the like.
    /// </summary>
    [Serializable]
    public struct RuntimeID : IEquatable<RuntimeID>
    {
        static System.Random random;
        static RuntimeID()
        {
            random = new System.Random();
        }
        //public readonly Guid id;
        [SerializeField] long val; 

        public RuntimeID(long id) 
        {
            val = id;
        }

        public bool Equals(RuntimeID other)
        {
            return val.Equals(other.val);
        }

        public override bool Equals(object obj)
        {
            return obj is RuntimeID other && Equals(other);
        }

        public override int GetHashCode()
        {
            return val.GetHashCode();
        }

        public static bool operator ==(RuntimeID lhs, RuntimeID rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(RuntimeID lhs, RuntimeID rhs)
        {
            return !lhs.Equals(rhs);
        }

        public override string ToString()
        {
            return val.ToString();
        }

        /// <summary>
        ///     Produces a new ItemID using the default GUID generator.
        /// </summary>
        public static RuntimeID Random()
        {
            return new RuntimeID(random.NextLong());
        }
    }
}