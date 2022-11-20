using Zenject;

namespace Split.Infrastructure.ServicesFolder.StartLevel
{
    public class StartLevelServiceInstaller : Installer<StartLevelServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IStartLevelService>().To<StartLevelService>().AsSingle();
        }
    }
}