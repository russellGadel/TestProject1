using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Agent
{
    public sealed class BlockAgentShootToPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockAgentShootToPlayerComponent> _blockEvent = null;

        public void Run()
        {
            foreach (int idx in _blockEvent)
            {
                ref BlockAgentShootToPlayerComponent block = ref _blockEvent.Get1(idx);

                ref float timer = ref block.Timer;

                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    ref EcsEntity entity = ref _blockEvent.GetEntity(idx);
                    entity.Del<BlockAgentShootToPlayerComponent>();
                }
            }
        }
    }
}