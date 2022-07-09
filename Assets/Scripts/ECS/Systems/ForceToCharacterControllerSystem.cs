using ECS.Components;
using ECS.Components.CharacterControllerComponent;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class ForceToCharacterControllerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterControllerComponent, ForceComponent>
            _controller = null;

        private const int ForceDecayIntensity = 4;
        private const double SmallMagnitudeCorrection = 0.2;

        public void Run()
        {
            foreach (int idx in _controller)
            {
                ref CharacterControllerComponent characterController = ref _controller.Get1(idx);
                ref ForceComponent forceComponent = ref _controller.Get2(idx);

                if (forceComponent.Force.magnitude > SmallMagnitudeCorrection)
                {
                    characterController.value.Move(forceComponent.Force * Time.fixedDeltaTime);
                }
                
                forceComponent.Force = Vector3.Lerp(forceComponent.Force, Vector3.zero,
                    ForceDecayIntensity * Time.fixedDeltaTime);
                
                if (forceComponent.Force == Vector3.zero)
                {
                    ref EcsEntity entity = ref _controller.GetEntity(idx);
                    entity.Del<ForceComponent>();
                }
            }
        }
    }
}