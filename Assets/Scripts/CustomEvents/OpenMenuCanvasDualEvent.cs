using Core.EventsLoader;
using CustomUI.CustomCamera;
using CustomUI.GameplayCanvas;
using CustomUI.MenuCanvas;
using Zenject;

namespace CustomEvents
{
    public class OpenMenuCanvasDualEvent : ICustomDualEvent
    {
        private readonly IMenuCanvasView _menuMenuCanvasView;
        private readonly ICameraView _menuCameraView;
        private readonly IGameplayCanvasView _gameplayCanvasView;
        
        [Inject]
        public OpenMenuCanvasDualEvent(IMenuCanvasView menuMenuCanvasView
            , ICameraView menuCameraView, IGameplayCanvasView gameplayCanvasView)
        {
            _menuMenuCanvasView = menuMenuCanvasView;
            _menuCameraView = menuCameraView;
            _gameplayCanvasView = gameplayCanvasView;
        }

        public void Execute()
        {
            _gameplayCanvasView.Close();
            
            _menuMenuCanvasView.Open();
            _menuCameraView.Activate();
        }

        public void Undo()
        {
            _menuMenuCanvasView.Close();
            _menuCameraView.Deactivate();
            
            _gameplayCanvasView.Open();
        }
    }
}