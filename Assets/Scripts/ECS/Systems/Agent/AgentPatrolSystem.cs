using ECS.Components.AgentCurrentDataComponent;
using ECS.Components.AgentPosition;
using ECS.Components.NavMeshAgentComponent;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.Agent;
using Leopotam.Ecs;

namespace ECS.Systems.Agent
{
    public sealed class AgentPatrolSystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<AgentTag, AgentPatrolTag, NavMeshAgentComponent, AgentPositionsComponent,
                AgentCurrentDataComponent, ActiveObjectTag> _agents = null;

        private readonly MainSceneData _mainSceneData = null;
        private const int FirstAgentGoalIndex = 0;

        public void Run()
        {
            foreach (var agentIdx in _agents)
            {
                ref NavMeshAgentComponent agentNavMesh = ref _agents.Get3(agentIdx);
                ref AgentPositionsComponent agentPositions = ref _agents.Get4(agentIdx);
                ref AgentCurrentDataComponent data = ref _agents.Get5(agentIdx);

                if (agentNavMesh.value.remainingDistance < _mainSceneData.AgentsSettings.DistanceToChangeGoal)
                {
                    ref int currentPositionIndex = ref data.CurrentGoalPositionIndex;
                    currentPositionIndex += 1;

                    if (IsPatrolledAllGoals(currentPositionIndex, agentPositions))
                    {
                        currentPositionIndex = FirstAgentGoalIndex;
                    }

                    SetNextDestination(agentNavMesh, agentPositions, currentPositionIndex);
                }
            }
        }
        
        private bool IsPatrolledAllGoals(in int currentPositionIndex, in AgentPositionsComponent agentPositions)
        {
            return currentPositionIndex == agentPositions.patrolGoalsPositions.Length;
        }
        
        private void SetNextDestination(in NavMeshAgentComponent agentNavMesh,
            in AgentPositionsComponent agentPositions, in int currentPositionIndex)
        {
            agentNavMesh.value.destination =
                agentPositions.patrolGoalsPositions[currentPositionIndex].position;
        }
    }
}