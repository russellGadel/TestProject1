using ECS.CustomConvertToEntity;
using ECS.References.MainScene;
using ECS.Systems.Agent;
using ECS.Systems.Events;
using ECS.Systems.Events.Bullet;
using ECS.Systems.Events.LoadingWindow;
using ECS.Systems.Events.ObjectsActivitySystem;
using ECS.Systems.Events.Weapon;
using ECS.Systems.Init;
using ECS.Systems.Player;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public sealed class MainSceneUpdateSystem : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private MainSceneData _mainSceneData;
        private MainSceneServices _mainSceneServices;
        private MainSceneUIViews _mainSceneUIViews;


        public void Construct(in EcsWorld world
            , in MainSceneData mainSceneData
            , in MainSceneUIViews mainSceneUIViews
            , in MainSceneServices mainSceneServices)
        {
            _world = world;

            _mainSceneData = mainSceneData;
            _mainSceneUIViews = mainSceneUIViews;
            _mainSceneServices = mainSceneServices;

            _systems = new EcsSystems(_world);
            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        public void Run()
        {
            _systems.Run();
        }


        private void AddInjections()
        {
            _systems
                .Inject(_mainSceneData)
                .Inject(_mainSceneUIViews)
                .Inject(_mainSceneServices);
        }

        private void AddOneFrames()
        {
        }

        private void AddSystems()
        {
            _systems
                //PreInit
                .Add(new CustomWorldPreInitSystem())

                // Init
                .Add(new InitObjectsFactorySystem())
                //

                // LastInit
                .Add(new InitUIGameSystem())
                .Add(new InitAgentSystem())
                .Add(new InitWeaponsSystem())
                .Add(new InitBulletsSystem())
                .Add(new InitGameEntitySystem())

                
                // Run Init OneFrame
                .Add(new RunInitBulletSystem())
                
                //Run
                .Add(new PlayerAimingOnAgentSystem())
                // OneFrame
                .Add(new SpawnPlayerAtInitPositionEventSystem())
                .Add(new SpawnAgentsAtInitPositionsSystem())
                .Add(new AgentAttackPlayerSystem())
                .Add(new AgentShootToPlayerSystem())
                .Add(new WeaponShootEventSystem())
                .Add(new PlayerMouseInputSystem())
                .Add(new PlayerHitByBulletSystem())
                .Add(new SetInitialColorToAgentPlayerNoLongerAimAtSystem())
                //
                .Add(new BulletHitObjectEventSystem())
                .Add(new AgentHitByBulletEventSystem())
                .Add(new PlayerBulletHitAgentEventSystem())
                //
                .Add(new ImmediatelyLookAtPlayerSystem())
                //
                .Add(new DelayDeactivateObjectSystem())
                .Add(new ActivateObjectsSystem())
                .Add(new DeactivateObjectsSystem())

                //Block
                .Add(new BlockAgentShootToPlayerSystem())
                .Add(new BlockWeaponOneShootSystem())
                .Add(new BlockWeaponShootThenReloadSystem())
                .Add(new AgentStandStillSystem())
                .Add(new BlockChangeAgentStateSystem())
                .Add(new BlockPlayerGameOverSystem())

                // LastRun One Frame
                .Add(new CloseLoadingWindowSystem())

                // Run
                .Add(new ChangeAgentStateSystem())
                .Add(new AgentPatrolSystem())
                .Add(new CheckingPlayerOnGroundSystem())
                //
                .Add(new WinEventSystem())
                .Add(new GameOverEventSystem())
                .Add(new StopGamePlayEventSystem())

                //
                .Add(new StartGameEventSystem())
                ;
        }

        private void OnDestroy()
        {
            DestroySystems();
        }

        private void DestroySystems()
        {
            if (_systems == null) return;
            _systems.Destroy();
            _systems = null;
        }
    }
}