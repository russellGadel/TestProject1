using Services.Agents;
using Services.Bullets;
using Services.GamePlay;
using UnityEngine;
using Zenject;

namespace ECS.References.MainScene
{
    public class MainSceneData : MonoBehaviour
    {
        [Inject] public readonly GamePlaySettings GamePlaySettings;
        [Inject] public readonly IAgentsSettings AgentsSettings;
        [Inject] public readonly BulletsSettings BulletsSettings;
    }
}