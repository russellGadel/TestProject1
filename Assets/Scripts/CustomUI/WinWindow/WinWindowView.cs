using UnityEngine;

namespace CustomUI.WinWindow
{
    public sealed class WinWindowView : MonoBehaviour
        , IWinWindowView
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