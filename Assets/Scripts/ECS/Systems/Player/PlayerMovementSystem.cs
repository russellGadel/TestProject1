using ECS.Components.CharacterControllerComponent;
using ECS.Components.Direction;
using ECS.Components.MovementSpeed;
using ECS.Components.TransformComponent;
using ECS.Tags;
using ECS.Tags.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Player
{
    public sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag
            , CharacterControllerComponent
            , MovementSpeedComponent
            , DirectionComponent
            , TransformComponent>.Exclude<InactiveObjectTag> _ecsFilter = null;

        public void Run()
        {
            foreach (int entity in _ecsFilter)
            {
                ref CharacterControllerComponent characterControllerComponent = ref _ecsFilter.Get2(entity);
                ref MovementSpeedComponent movementSpeedComponent = ref _ecsFilter.Get3(entity);
                ref DirectionComponent directionComponent = ref _ecsFilter.Get4(entity);
                ref TransformComponent transformComponent = ref _ecsFilter.Get5(entity);

                ref CharacterController controller = ref characterControllerComponent.value;
                ref float speed = ref movementSpeedComponent.speed;
                ref Vector3 direction = ref directionComponent.Direction;
                ref Transform transform = ref transformComponent.value;
                
                Vector3 movement = direction*speed;
                movement = Vector3.ClampMagnitude(movement, speed);
                movement = transform.TransformDirection(movement);
                controller.Move(movement);
            }
        }
    }
}