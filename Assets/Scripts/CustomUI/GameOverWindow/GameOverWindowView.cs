using UnityEngine;

namespace CustomUI.GameOverWindow
{
    public sealed class GameOverWindowView : MonoBehaviour, IGameOverWindowView
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