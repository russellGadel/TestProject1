﻿using Core.EventsLoader;
using CustomUI.LoadingWindow;
using UnityEngine;
using ViewObjects.LoadingIndicator;
using Zenject;

namespace CustomEvents
{
    public sealed class OpenLoadingWindowDualEvent : ICustomDualEvent
    {
        private readonly ILoadingWindowView _loadingWindowView;
        private readonly ILoadingIndicatorView _loadingIndicatorView;

        [Inject]
        public OpenLoadingWindowDualEvent(ILoadingWindowView loadingWindowView
            , ILoadingIndicatorView loadingIndicatorView)
        {
            _loadingWindowView = loadingWindowView;
            _loadingIndicatorView = loadingIndicatorView;
        }


        public void Execute()
        {
            _loadingWindowView.SetGameVersion(GetGameVersion());

            _loadingWindowView.Open();
            _loadingIndicatorView.Open();
        }

        public void Undo()
        {
            _loadingIndicatorView.Close();
            _loadingWindowView.Close();
        }


        private string GetGameVersion()
        {
            return $"Version {Application.version}";
        }
    }
}