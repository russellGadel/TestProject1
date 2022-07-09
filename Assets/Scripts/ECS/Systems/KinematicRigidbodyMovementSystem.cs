using ECS.Components.MovementSpeed;
using ECS.Components.MoveTo;
using ECS.Components.TransformComponent;
using ECS.Tags;
using ECS.Tags.KinematicRigidbody;
using Leopotam.Ecs;

namespace ECS.Systems
{
    // Fixed Update
    public sealed class KinematicRigidbodyMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<KinematicRigidbodyTag, ActiveObjectTag
                , MoveToComponent, TransformComponent, MovementSpeedComponent>
            _bodies = null;

        public void Run()
        {
            foreach (int idx in _bodies)
            {
                ref MoveToComponent moveToComponent = ref _bodies.Get3(idx);
                ref TransformComponent transformComponent = ref _bodies.Get4(idx);
                ref MovementSpeedComponent movementSpeedComponent = ref _bodies.Get5(idx);

                transformComponent
                    .value
                    .Translate(moveToComponent.Direction * movementSpeedComponent.speed);
            }
        }
    }
}