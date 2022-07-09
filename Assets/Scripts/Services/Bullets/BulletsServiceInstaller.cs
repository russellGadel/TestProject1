using UnityEngine;
using Zenject;

namespace Services.Bullets
{
    public sealed class BulletsServiceInstaller : MonoInstaller
    {
        [SerializeField] private BulletsSettings _settings;

        public override void InstallBindings()
        {
            Container
                .Bind<BulletsSettings>()
                .FromInstance(_settings)
                .AsSingle();
        }
    }
}