using ECS.Components;
using ECS.Components.AgentPosition;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.Agent;
using ECS.Tags.Events;
using ECS.Tags.Events.LoadingWindow;
using ECS.Tags.Player;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame
    public sealed class StartGameEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartGameEcsEventTag> _startGameEvent = null;

        public void Run()
        {
            foreach (int eventIdx in _startGameEvent)
            {
                OpenLoadingWindow();
                
                ResetLastGameSessionData();
                
                SpawnPlayer();

                VacateAgentsPositions();
                SpawnAgents();

                CloseLoadingWindow();

                ref EcsEntity startGameEntity = ref _startGameEvent.GetEntity(eventIdx);
                startGameEntity.Del<StartGameEcsEventTag>();
            }
        }


        private readonly MainSceneServices _services = null;

        private void OpenLoadingWindow()
        {
            _services.MainSceneEventsService.OpenLoadingWindowDualEvent.Execute();
        }

        
        private readonly EcsFilter<GameTag, CurrentGameSessionDataComponent> _currentGameSession;

        private void ResetLastGameSessionData()
        {
            foreach (int idx in _currentGameSession)
            {
                ref CurrentGameSessionDataComponent gameData = ref _currentGameSession.Get2(idx);
                gameData.DeactivatedAgentsAmount = 0;
            }
        }


        private readonly EcsFilter<PlayerTag> _player = null;

        private void SpawnPlayer()
        {
            foreach (int idx in _player)
            {
                ref EcsEntity playerEntity = ref _player.GetEntity(idx);
                playerEntity.Replace(new SpawnObjectEventTag());
            }
        }


        private readonly EcsFilter<AgentElementTag, AgentPositionsComponent> _agentsSpawnPositions = null;


        private void VacateAgentsPositions()
        {
            foreach (int idx in _agentsSpawnPositions)
            {
                ref EcsEntity entity = ref _agentsSpawnPositions.GetEntity(idx);
                entity.Replace(new FreeStatusTag());
            }
        }

        private readonly EcsFilter<AgentTag> _agents;


        private void SpawnAgents()
        {
            foreach (var idx in _agents)
            {
                ref EcsEntity agentEntity = ref _agents.GetEntity(idx);
                agentEntity.Replace(new SpawnObjectEventTag());
            }
        }


        private readonly EcsFilter<UIGameTag> _gameUI = null;

        private void CloseLoadingWindow()
        {
            foreach (var idx in _gameUI)
            {
                ref EcsEntity entity = ref _gameUI.GetEntity(idx);
                entity.Replace(new CloseLoadingWindowTag());
            }
        }
    }
}