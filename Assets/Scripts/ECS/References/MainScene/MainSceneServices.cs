using Core.CustomInvoker;
using ScenesBootstrapper.MainScene.Events;
using Services.CursorService;
using UnityEngine;
using Zenject;

namespace ECS.References.MainScene
{
    public class MainSceneServices : MonoBehaviour
    {
        [Inject] public readonly ICustomInvokerService InvokerService;
        [Inject] public readonly MainSceneEventsService MainSceneEventsService;
    }
}