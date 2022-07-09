using UnityEngine;
using Zenject;

namespace Services.GamePlay
{
    public sealed class GamePlayInstaller : MonoInstaller
    {
        [SerializeField] private GamePlaySettings _settings;

        public override void InstallBindings()
        {
            Container
                .Bind<GamePlaySettings>().FromInstance(_settings)
                .AsSingle();
        }
    }
}