using System;
using System.Collections;
using System.Globalization;
using Core.EventsLoader;
using CustomUI.StartWindow;
using ECS.Tags.Events;
using Leopotam.Ecs;
using Services.CursorService;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace CustomEvents
{
    public sealed class StartWindowEvents : ICustomEventLoader,
        IDisposable
    {
        private readonly IStartWindowView _startWindowView;
        private readonly OpenLoadingWindowDualEvent _openLoadingWindowDualEvent;
        private readonly ICursorService _cursorService;

        [Inject]
        private StartWindowEvents(IStartWindowView startWindowView
            , OpenLoadingWindowDualEvent openLoadingWindowDualEvent, ICursorService cursorService)
        {
            _startWindowView = startWindowView;
            _openLoadingWindowDualEvent = openLoadingWindowDualEvent;
            _cursorService = cursorService;
        }

        public IEnumerator Load()
        {
            SubscribeToStartButton();

            yield return null;
        }

        public void Execute()
        {
            _startWindowView.Open();
        }

        void IDisposable.Dispose()
        {
            UnsubscribeFromStartButton();
        }


        private void SubscribeToStartButton()
        {
            _startWindowView.SubscribeToPressStartGameButton(ObserversPressStartButton);
        }

        private void UnsubscribeFromStartButton()
        {
            _startWindowView.UnsubscribeFromPressStartGameButton(ObserversPressStartButton);
        }


        private void ObserversPressStartButton()
        {
            _cursorService.Lock();
            _startWindowView.Close();
            _openLoadingWindowDualEvent.Execute();
            StartEcsGame();
        }

        private static void StartEcsGame()
        {
            EcsEntity startGameEntity = WorldHandler.GetWorld().NewEntity();
            startGameEntity.Replace(new StartGameEcsEventTag());
        }
    }
}