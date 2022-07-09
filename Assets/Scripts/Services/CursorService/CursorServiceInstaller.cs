using Zenject;

namespace Services.CursorService
{
    public class CursorServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICursorService>().To<CursorService>().AsSingle();
        }
    }
}