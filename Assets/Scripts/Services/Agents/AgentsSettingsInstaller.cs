using UnityEngine;
using Zenject;

namespace Services.Agents
{
    public sealed class AgentsSettingsInstaller : MonoInstaller
    {
        [SerializeField] private AgentsSettings _agentSettings;

        public override void InstallBindings()
        {
            Container
                .Bind<IAgentsSettings>()
                .FromInstance(_agentSettings)
                .AsSingle();
        }
    }
}