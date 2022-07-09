using ECS.Components.RigidbodyComponent;
using ECS.Components.TransformComponent;
using ECS.Tags.Events;
using ECS.Tags.Player;
using Extensions;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One frame
    public sealed class ImmediatelyLookAtPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ImmediatelyLookAtPlayerTag, RigidbodyComponent> _playerObservers = null;
        private readonly EcsFilter<PlayerTag, TransformComponent> _playerPosition = null;
        
        public void Run()
        {
            foreach (int observerIdx in _playerObservers)
            {
                ref RigidbodyComponent observerRigidbody = ref _playerObservers.Get2(observerIdx);

                foreach (int playerIdx in _playerPosition)
                {
                    ref TransformComponent playerTransform = ref _playerPosition.Get2(playerIdx);

                    observerRigidbody.value.LookAtObjectImmediately(playerTransform.value.position);
                }

                
                ref EcsEntity observerEntity = ref _playerObservers.GetEntity(observerIdx);
                observerEntity.Del<ImmediatelyLookAtPlayerTag>();
            }
        }
    }
}