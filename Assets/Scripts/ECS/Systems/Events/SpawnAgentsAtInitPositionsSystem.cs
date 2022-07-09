using ECS.Components.AgentCurrentDataComponent;
using ECS.Components.AgentPosition;
using ECS.Components.ObjectsFactory;
using ECS.Components.TransformComponent;
using ECS.Tags;
using ECS.Tags.Agent;
using ECS.Tags.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events
{
    // One frame
    public sealed class SpawnAgentsAtInitPositionsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AgentTag, TransformComponent, SpawnObjectEventTag> _agents = null;

        private bool _isHasFreePositions;

        public void Run()
        {
            foreach (int agentIdx in _agents)
            {
                CheckAgentsAmountAndCreateIfNeed();

                ref EcsEntity agentEntity = ref _agents.GetEntity(agentIdx);

                SpawnAgent(agentIdx, agentEntity, out _isHasFreePositions);

                agentEntity.Del<SpawnObjectEventTag>();
            }
        }


        private readonly EcsFilter<AgentElementTag, ObjectsFactoryComponent> _factory = null;

        private void CheckAgentsAmountAndCreateIfNeed()
        {
            foreach (int agentsFactory in _factory)
            {
                ref ObjectsFactoryComponent objectsFactoryComponent = ref _factory.Get2(agentsFactory);

                if (_factory.GetEntitiesCount() < objectsFactoryComponent.value.MinBufferElementsAtPool)
                {
                    objectsFactoryComponent.value.CreateAdditionalElements();
                }

                break;
            }
        }


        private readonly EcsFilter<AgentElementTag, AgentPositionsComponent, FreeStatusTag> _positions = null;


        private void SpawnAgent(in int agentIdx, in EcsEntity agentEntity, out bool isHasFreePositions)
        {
            foreach (int positionIdx in _positions)
            {
                ref TransformComponent agentTransform = ref _agents.Get2(agentIdx);
                ref AgentPositionsComponent positionsComponent = ref _positions.Get2(positionIdx);
                agentTransform.value.position = positionsComponent.spawnTransform.position;

                ref EcsEntity positionEntity = ref _positions.GetEntity(positionIdx);
                positionEntity.Del<FreeStatusTag>();

                agentEntity.Replace(positionsComponent);

                agentEntity.Replace(new AgentCurrentDataComponent()
                {
                    CurrentGoalPositionIndex = GetFirstRandomAgentGoal(positionsComponent),
                    CurrentCartridgeInFiringQueue = 0,
                    CurrentHitsNumberByPlayer = 0
                });

                if (agentEntity.Has<AgentShootToPlayerTag>())
                {
                    agentEntity.Del<AgentShootToPlayerTag>();
                }
                
                agentEntity.Replace(new ActivateObjectEventTag());
                agentEntity.Replace(new AgentPatrolTag());
                agentEntity.Replace(new PermanentlyLookAtPlayerTag());


                isHasFreePositions = true;
                break;
            }

            isHasFreePositions = false;
        }

        private int GetFirstRandomAgentGoal(in AgentPositionsComponent positionsComponent)
        {
            return Random.Range(0, positionsComponent.patrolGoalsPositions.Length);
        }
    }
}