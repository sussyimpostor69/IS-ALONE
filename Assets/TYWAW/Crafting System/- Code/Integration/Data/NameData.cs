using System;

namespace PolyPerfect.Crafting.Integration
{
    [Serializable]
    public struct NameData
    {
        public string Name;

        public NameData(string name)
        {
            Name = name;
        }
    }
}