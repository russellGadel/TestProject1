using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitUIGameSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            EcsEntity entity = _world.NewEntity();
            entity.Replace(new UIGameTag());
        }
    }
}