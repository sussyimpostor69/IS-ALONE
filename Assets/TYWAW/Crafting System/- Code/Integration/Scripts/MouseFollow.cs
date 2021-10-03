using UnityEngine;

namespace PolyPerfect.Crafting.Integration.UGUI
{
    public class MouseFollow : MonoBehaviour
    {
        void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}