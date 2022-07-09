using UnityEngine;
using Zenject;

namespace CustomUI.CustomCamera
{
    public sealed class CameraViewInstaller : MonoInstaller
    {
        [SerializeField] private CameraView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<ICameraView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}