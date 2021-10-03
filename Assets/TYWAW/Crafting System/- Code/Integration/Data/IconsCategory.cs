using System.Collections.Generic;
using UnityEngine;
using DATA_TYPE = PolyPerfect.Crafting.Integration.IconData;

namespace PolyPerfect.Crafting.Integration
{
    [CreateMenuTitle("With Sprite")]
    [CreateAssetMenu]
    public class IconsCategory : BaseCategoryWithData<DATA_TYPE>
    {
        [SerializeField] List<DATA_TYPE> data = new List<DATA_TYPE>();

        public override string __Usage => "Container for sprite icons.";

        public override IReadOnlyList<DATA_TYPE> Data => data;

        protected override void SetDataInternal(int index, DATA_TYPE value)
        {
            data[index] = value;
        }
    }
}