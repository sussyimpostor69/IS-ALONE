using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace PolyPerfect.Crafting.Edit
{
    /// <summary>
    ///     Uses the Unity Editor's DragAndDrop functionality.
    /// </summary>
    public class DataDragManipulator<T> : MouseManipulator where T : Object
    {
        readonly Func<T> getData;
        bool isViable;
        readonly float requiredDelta = 5f;
        Vector2 startLocation;

        public DataDragManipulator(Func<T> getData)
        {
            this.getData = getData;
            activators.Add(new ManipulatorActivationFilter {button = MouseButton.LeftMouse});
        }

        bool isDragging => DragAndDrop.visualMode != DragAndDropVisualMode.None;

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<MouseDownEvent>(HandleMouseDown);
            target.RegisterCallback<MouseMoveEvent>(HandleMouseMove);
            target.RegisterCallback<MouseUpEvent>(HandleMouseUp);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<MouseDownEvent>(HandleMouseDown);
        }

        void HandleMouseDown(MouseDownEvent evt)
        {
            if (!CanStartManipulation(evt))
                return;
            DragAndDrop.PrepareStartDrag();
            DragAndDrop.visualMode = DragAndDropVisualMode.None;
            target.CaptureMouse();
            isViable = true;
            startLocation = evt.mousePosition;
        }

        void HandleMouseMove(MouseMoveEvent evt)
        {
            if (!isViable || isDragging)
                return;

            if (Vector2.Distance(startLocation, evt.mousePosition) > requiredDelta)
                BeginDrag();
        }

        void BeginDrag()
        {
            DragAndDrop.PrepareStartDrag();
            DragAndDrop.StartDrag($"{typeof(T).Name} Drag");
            DragAndDrop.objectReferences = new Object[] {getData()};
            target.ReleaseMouse();
            isViable = false;
        }

        void HandleMouseUp(MouseUpEvent evt)
        {
            target.ReleaseMouse();
            isViable = false;
        }
    }
}