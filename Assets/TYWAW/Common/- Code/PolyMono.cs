using UnityEditor;
using UnityEngine;

namespace PolyPerfect.Common
{
    public abstract class PolyMono : MonoBehaviour
    {
        public abstract string __Usage { get; }

        protected void ForceEditorRedraw()
        {
#if UNITY_EDITOR
            if (gameObject != Selection.activeGameObject)
                return;

            var obj = Selection.activeObject;
            Selection.activeObject = null;
            EditorApplication.delayCall += () => Selection.activeObject = obj;
#endif
        }
    }
}