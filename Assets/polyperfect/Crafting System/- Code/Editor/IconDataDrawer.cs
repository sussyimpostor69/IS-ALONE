using PolyPerfect.Common;
using PolyPerfect.Crafting.Integration;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace PolyPerfect.Crafting.Edit
{
    [CustomPropertyDrawer(typeof(IconData))]
    public class IconDataDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var ve = new VisualElement().SetRow().SetGrow();
            var iconProp = property.FindPropertyRelative(nameof(IconData.Icon));

            var field = new PropertyField(iconProp);
            ve.Add(field);
            return ve;
        }
    }
}