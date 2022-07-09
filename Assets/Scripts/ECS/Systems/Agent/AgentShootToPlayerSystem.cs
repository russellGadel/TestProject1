using ECS.Components;
using ECS.Components.AgentCurrentDataComponent;
using ECS.Components.RefToWeapon;
using ECS.Components.Weapon;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.Agent;
using ECS.Tags.Events.Weapon;
using ECS.Triggers;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Agent
{
    public sealed class AgentShootToPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentShootToPlayerTag, AgentCurrentDataComponent, RefToWeaponsComponent,
                ActiveObjectTag>.Exclude<BlockAgentShootToPlayerComponent> _agentShootEvent = null;

        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (int idxEvent in _agentShootEvent)
            {
                ref RefToWeaponsComponent weapons = ref _agentShootEvent.Get3(idxEvent);

                ref Transform weaponMuzzleTransform =
                    ref weapons.mainWeapon.Entity.Get<WeaponComponent>().muzzleTransformForBullet;

                Ray ray = new Ray(weaponMuzzleTransform.position, weaponMuzzleTransform.forward);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.CompareTag(UnityTags.Player.ToString()))
                    {
                        ShootToPlayer(weapons, idxEvent);
                    }
                }
            }
        }

        private void ShootToPlayer(in RefToWeaponsComponent weapons, in int idxEvent)
        {
            weapons.mainWeapon.Entity.Replace(new WeaponShootEventTag());
            ref EcsEntity agentEntity = ref _agentShootEvent.GetEntity(idxEvent);
            ref AgentCurrentDataComponent _currentData = ref _agentShootEvent.Get2(idxEvent);

            _currentData.CurrentCartridgeInFiringQueue += 1;
            
            if (_currentData.CurrentCartridgeInFiringQueue >=
                _mainSceneData.AgentsSettings.NumbersOfCartridgesInFiringQueuePerPlayer)
            {
                _currentData.CurrentCartridgeInFiringQueue = 0;
                
                agentEntity.Replace(new BlockAgentShootToPlayerComponent()
                    {
                        Timer = _mainSceneData.AgentsSettings.DelayFiringQueue
                    }
                );
            }

            agentEntity.Replace(new BlockAgentShootToPlayerComponent()
            {
                Timer = _mainSceneData.AgentsSettings.DelayOneShot
            });
        }
    }
}