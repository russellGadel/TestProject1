using UnityEngine;
using Zenject;

namespace CustomUI.MenuCanvas
{
    public sealed class MenuCanvasViewInstaller : MonoInstaller
    {
        [SerializeField] private MenuCanvasView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<IMenuCanvasView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}