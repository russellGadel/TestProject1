using CustomEvents;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class MainSceneEventsService
    {
        [Inject] public readonly OpenLoadingWindowDualEvent OpenLoadingWindowDualEvent;
        [Inject] public readonly OpenMenuCanvasDualEvent OpenMenuCanvasDualEvent;
        [Inject] public readonly StartWindowEvents StartWindowEvents;
        [Inject] public readonly GameOverEvent GameOverEvent;
        [Inject] public readonly WinEvent WinEvent;
    }
}