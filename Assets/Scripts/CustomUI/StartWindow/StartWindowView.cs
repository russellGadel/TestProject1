using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomUI.StartWindow
{
    public sealed class StartWindowView : MonoBehaviour
        , IStartWindowView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }


        [SerializeField] private Button _startGameButton;

        public void SubscribeToPressStartGameButton(UnityAction observer)
        {
            _startGameButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromPressStartGameButton(UnityAction observer)
        {
            _startGameButton.onClick.RemoveListener(observer);
        }
    }
}