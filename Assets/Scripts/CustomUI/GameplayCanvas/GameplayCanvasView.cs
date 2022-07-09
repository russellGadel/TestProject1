using UnityEngine;

namespace CustomUI.GameplayCanvas
{
    public sealed class GameplayCanvasView : MonoBehaviour
        , IGameplayCanvasView
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