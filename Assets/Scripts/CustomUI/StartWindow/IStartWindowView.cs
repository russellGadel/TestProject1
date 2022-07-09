using Core.InstallersExecutor;
using UnityEngine.Events;

namespace CustomUI.StartWindow
{
    public interface IStartWindowView
    {
        void Open();
        void Close();

        void SubscribeToPressStartGameButton(UnityAction observer);
        void UnsubscribeFromPressStartGameButton(UnityAction observer);
    }
}