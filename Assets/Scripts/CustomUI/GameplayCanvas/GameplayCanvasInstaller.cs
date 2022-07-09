using UnityEngine;
using Zenject;

namespace CustomUI.GameplayCanvas
{
    public sealed class GameplayCanvasInstaller : MonoInstaller
    {
        [SerializeField] private GameplayCanvasView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<IGameplayCanvasView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}