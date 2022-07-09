using ECS.Components.RefToWeapon;
using ECS.Components.TransformComponent;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.AimingPoint;
using ECS.Tags.Events;
using ECS.Tags.PlayerElementsTag;
using Extensions;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    public sealed class PermanentlyLookAtPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PermanentlyLookAtPlayerTag, TransformComponent, RefToWeaponsComponent,
                ActiveObjectTag> _playerObservers = null;

        private readonly EcsFilter<PlayerElementsTag, AimingPointTag, TransformComponent> _playerPosition = null;

        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (int observerIdx in _playerObservers)
            {
                ref TransformComponent observerTransform = ref _playerObservers.Get2(observerIdx);


                foreach (int playerIdx in _playerPosition)
                {
                    ref TransformComponent playerTransform = ref _playerPosition.Get3(playerIdx);
                    RotateBody(observerTransform, playerTransform);
                    RotateWeapon(observerIdx, playerTransform);
                }
            }
        }

        private void RotateBody(in TransformComponent observerTransform, in TransformComponent playerTransform)
        {
            observerTransform.value.LookAtObjectAtFixedUpdate(playerTransform.value.position,
                _mainSceneData.AgentsSettings.BodyRotationSpeed);
        }

        private void RotateWeapon(in int observerIdx, in TransformComponent playerTransform)
        {
            ref RefToWeaponsComponent weaponsComponent = ref _playerObservers.Get3(observerIdx);
            ref TransformComponent weaponTransform =
                ref weaponsComponent.mainWeapon.Entity.Get<TransformComponent>();
            weaponTransform.value.LookAtObjectAtFixedUpdate(playerTransform.value.position,
                _mainSceneData.AgentsSettings.BodyRotationSpeed);
        }
    }
}