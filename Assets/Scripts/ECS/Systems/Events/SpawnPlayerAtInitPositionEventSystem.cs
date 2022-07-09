using ECS.Components.GameObjectComponent;
using ECS.Components.SpawnPoint;
using ECS.Components.TransformComponent;
using ECS.Components.Weapon;
using ECS.Tags;
using ECS.Tags.CameraTag;
using ECS.Tags.Events;
using ECS.Tags.Player;
using ECS.Tags.PlayerElementsTag;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events
{
    // One Frame
    public sealed class SpawnPlayerAtInitPositionEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, SpawnObjectEventTag, TransformComponent, InactiveObjectTag>
            _spawnPlayerEvent = null;

        public void Run()
        {
            foreach (int idx in _spawnPlayerEvent)
            {
                ref TransformComponent playerTransform = ref _spawnPlayerEvent.Get3(idx);

                Deactivate(in playerTransform.value);

                Spawn(in playerTransform.value);

                ActivatePlayer(in playerTransform.value);
                ActivatePlayerCamera();
                ActivatePlayerWeapon();

                ref EcsEntity spawnPlayerEventEntity = ref _spawnPlayerEvent.GetEntity(idx);
                spawnPlayerEventEntity.Del<SpawnObjectEventTag>();
            }
        }

        private void Deactivate(in Transform playerTransform)
        {
            playerTransform.gameObject.SetActive(false);
        }


        private readonly EcsFilter<PlayerElementsTag, SpawnPointComponent> _playerSpawnPoint = null;

        private void Spawn(in Transform playerTransform)
        {
            ref SpawnPointComponent spawnPoint = ref _playerSpawnPoint.Get2(0);
            playerTransform.position = spawnPoint.value.position;
        }


        private void ActivatePlayer(in Transform playerTransform)
        {
            foreach (var idx in _spawnPlayerEvent)
            {
                ref EcsEntity entity = ref _spawnPlayerEvent.GetEntity(idx);
                entity.Replace(new ActivateObjectEventTag());
            }

            playerTransform.gameObject.SetActive(true);
        }

        private readonly EcsFilter<PlayerElementsTag, CameraTag, GameObjectComponent> _playerCamera = null;

        private void ActivatePlayerCamera()
        {
            foreach (int playerIdx in _playerCamera)
            {
                ref GameObjectComponent cameraComponent = ref _playerCamera.Get3(playerIdx);
                cameraComponent.gameObject.SetActive(true);
            }
        }


        private readonly EcsFilter<PlayerElementsTag, WeaponComponent> _playerWeapon = null;

        private void ActivatePlayerWeapon()
        {
            foreach (int playerIdx in _playerWeapon)
            {
                ref EcsEntity playerWeaponEntity = ref _playerWeapon.GetEntity(playerIdx);
                playerWeaponEntity.Replace(new ActivateObjectEventTag());
            }
        }
    }
}