using ECS.Components.Direction;
using ECS.Tags;
using ECS.Tags.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Player
{
    public sealed class PlayerMovementInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent>
            .Exclude<InactiveObjectTag> _player = null;

        private float _directionY;

        public void Init()
        {
            _directionY = Physics.gravity.y;
        }

        public void Run()
        {
            foreach (int entity in _player)
            {
                ref DirectionComponent directionComponent = ref _player.Get2(entity);
                ref Vector3 direction = ref directionComponent.Direction;

                direction.x = Input.GetAxis("Horizontal");
                direction.z = Input.GetAxis("Vertical");
                direction.y = _directionY;
            }
        }
    }
}