using UnityEngine;
using Zenject;

namespace CustomUI.GameOverWindow
{
    public class GameOverWindowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameOverWindowPresenter>()
                .FromMethod(InstallPresenter)
                .AsSingle();
        }

        
        [SerializeField] private GameOverWindowSettings _settings;
        [SerializeField] private GameOverWindowView _view;

        private GameOverWindowPresenter InstallPresenter()
        {
            return new GameOverWindowPresenter(_settings, _view);
        }
    }
}