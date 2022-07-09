using ECS.Components;
using ECS.Components.CharacterControllerComponent;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.Events;
using ECS.Tags.Player;
using Leopotam.Ecs;

namespace ECS.Systems.Player
{
    public sealed class CheckingPlayerOnGroundSystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<PlayerTag, CharacterControllerComponent, ActiveObjectTag>
            .Exclude<BlockPlayerGameOverComponent> _player = null;

        private readonly EcsFilter<GameTag> _game;
        
        private readonly MainSceneData _mainSceneData = null;
        private int _checkGameOverAttempt = 0;

        public void Run()
        {
            foreach (int playerIdx in _player)
            {
                ref CharacterControllerComponent characterController = ref _player.Get2(playerIdx);
                
                if (characterController.value.isGrounded == false)
                {
                    _checkGameOverAttempt += 1;

                    if (_checkGameOverAttempt == 1)
                    {
                        ref EcsEntity _player = ref this._player.GetEntity(playerIdx);
                        _player.Replace(new BlockPlayerGameOverComponent()
                        {
                            Timer = _mainSceneData.GamePlaySettings.timeDelayBeforeGameOverPlayer
                        });
                    }

                    if (_checkGameOverAttempt == 2)
                    {
                        foreach (int gameIdx in _game)
                        {
                            ref EcsEntity gameEntity = ref _game.GetEntity(gameIdx);
                            gameEntity.Replace(new GameOverEventTag());
                            break;
                        }
                    }
                }
                else
                {
                    _checkGameOverAttempt = 0;
                }
            }
        }
    }
}