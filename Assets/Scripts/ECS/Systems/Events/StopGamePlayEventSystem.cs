using ECS.Components.GameObjectComponent;
using ECS.Components.Weapon;
using ECS.Tags.Agent;
using ECS.Tags.CameraTag;
using ECS.Tags.Events;
using ECS.Tags.Player;
using ECS.Tags.PlayerElementsTag;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame
    public sealed class StopGamePlayEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StopGamePlayEventTag> _event = null;

        public void Run()
        {
            foreach (int idx in _event)
            {
                DeactivateAgents();
                DeactivatePlayerWeapon();
                DeactivatePlayerCamera();
                DeactivatePlayer();

                ref EcsEntity entity = ref _event.GetEntity(idx);
                entity.Del<StopGamePlayEventTag>();
            }
        }

        private readonly EcsFilter<PlayerElementsTag, CameraTag, GameObjectComponent> _playerCamera = null;

        private void DeactivatePlayerCamera()
        {
            foreach (int playerIdx in _playerCamera)
            {
                ref GameObjectComponent cameraComponent = ref _playerCamera.Get3(playerIdx);
                cameraComponent.gameObject.SetActive(false);
            }
        }


        private readonly EcsFilter<PlayerElementsTag, WeaponComponent> _playerWeapon = null;

        private void DeactivatePlayerWeapon()
        {
            foreach (int playerIdx in _playerWeapon)
            {
                ref EcsEntity playerWeaponEntity = ref _playerWeapon.GetEntity(playerIdx);
                playerWeaponEntity.Replace(new DeactivateObjectEventTag());
            }
        }

        private readonly EcsFilter<PlayerTag> _player;

        private void DeactivatePlayer()
        {
            foreach (int idx in _player)
            {
                ref EcsEntity entity = ref _player.GetEntity(idx);
                entity.Replace(new DeactivateObjectEventTag());
            }
        }


        private readonly EcsFilter<AgentTag> _agents = null;

        private void DeactivateAgents()
        {
            foreach (int idx in _agents)
            {
                ref EcsEntity weaponEntity = ref _agents.GetEntity(idx);
                weaponEntity.Replace(new DeactivateObjectEventTag());
            }
        }
    }
}