using ECS.References.MainScene;
using ECS.Systems;
using ECS.Systems.Events;
using ECS.Systems.Player;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public sealed class MainSceneFixedUpdateSystem : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _system;

        private MainSceneData _mainSceneData;

        public void Construct(in EcsWorld world
            , in MainSceneData mainSceneData)
        {
            _world = world;

            _mainSceneData = mainSceneData;

            _system = new EcsSystems(_world);
            _system.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _system.Init();
        }

        public void Run()
        {
            _system.Run();
        }


        private void AddInjections()
        {
            _system
                .Inject(_mainSceneData);
        }

        private void AddOneFrames()
        {
        }

        private void AddSystems()
        {
            _system
                //Run
                .Add(new PermanentlyLookAtPlayerSystem())
                .Add(new KinematicRigidbodyMovementSystem())
                
                //
                .Add(new ForceToCharacterControllerSystem())
                .Add(new PlayerMovementInputSystem())
                .Add(new PlayerMovementSystem())
                .Add(new PlayerCameraRotationToMouseSystem());
        }

        private void OnDestroy()
        {
            DestroySystems();
        }

        private void DestroySystems()
        {
            if (_system == null) return;
            _system.Destroy();
            _system = null;
        }
    }
}