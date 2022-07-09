using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Player
{
    public sealed class BlockPlayerGameOverSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockPlayerGameOverComponent> _block;

        public void Run()
        {
            foreach (int idx in _block)
            {
                ref BlockPlayerGameOverComponent block = ref _block.Get1(idx);

                ref float timer = ref block.Timer;

                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    ref EcsEntity entity = ref _block.GetEntity(idx);
                    entity.Del<BlockPlayerGameOverComponent>();
                }
            }
        }
    }
}