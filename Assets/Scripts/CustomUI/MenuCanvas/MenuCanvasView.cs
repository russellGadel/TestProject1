using UnityEngine;

namespace CustomUI.MenuCanvas
{
    public sealed class MenuCanvasView : MonoBehaviour
        , IMenuCanvasView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}