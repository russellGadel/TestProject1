using ECS.Components;
using ECS.Tags.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events.ObjectsActivitySystem
{
    public sealed class DelayDeactivateObjectSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DelayDeactivateObjectComponent> _event = null;

        public void Run()
        {
            foreach (var idx in _event)
            {
                ref DelayDeactivateObjectComponent delayDeactivate = ref _event.Get1(idx);

                ref float timer = ref delayDeactivate.Timer;
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    ref EcsEntity entity = ref _event.GetEntity(idx);
                    entity.Del<DelayDeactivateObjectComponent>();
                    entity.Replace(new DeactivateObjectEventTag());
                }
            }
        }
    }
}