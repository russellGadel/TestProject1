using ECS.Components.ObjectsFactory;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitObjectsFactorySystem : IEcsInitSystem
    {
        private readonly EcsFilter<ObjectsFactoryComponent> _factories = null;

        public void Init()
        {
            foreach (int idx in _factories)
            {
                ref ObjectsFactoryComponent factory = ref _factories.Get1(idx);
                factory.value.Initialize();
            }
        }
    }
}