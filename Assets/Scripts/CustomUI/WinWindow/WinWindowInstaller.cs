using UnityEngine;
using Zenject;

namespace CustomUI.WinWindow
{
    public sealed class WinWindowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IWinWindowPresenter>()
                .FromMethod(InstallPresenter)
                .AsSingle();
        }

        [SerializeField] private WinWindowView _view;
        [SerializeField] private WinWindowSettings _settings;

        private IWinWindowPresenter InstallPresenter()
        {
            return new WinWindowPresenter(_view, _settings);
        }
    }
}