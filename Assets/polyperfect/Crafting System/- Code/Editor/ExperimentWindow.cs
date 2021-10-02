using PolyPerfect.Common.Edit;
using PolyPerfect.Crafting.Integration;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PolyPerfect.Crafting.Edit
{
    public class ExperimentWindow : EditorWindow
    {
        void OnEnable()
        {
            Debug.Log("This window is for testing random things as they come up, and should be removed before publishing.");
            var ve = rootVisualElement;
            var grid = new GridView<BaseObjectWithID>(new Vector2(100, 32),
                () => new Label(),
                (v, o) => v.Q<Label>().text = o.name,
                AssetUtility.FindAssetsOfType<BaseObjectWithID>);
            grid.StretchToParentSize();
            //ve.schedule.DoubleDelay(() => grid.RefreshItemList());
            ve.Add(grid);
        }

        [MenuItem("Window/Experiments Window")]
        static void CreateWindow()
        {
            GetWindow<ExperimentWindow>();
        }
    }
}