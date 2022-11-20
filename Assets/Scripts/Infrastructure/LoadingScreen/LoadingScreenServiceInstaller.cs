using Zenject;

namespace Split.Infrastructure.LoadingScreen
{
    public class LoadingScreenServiceInstaller : Installer<LoadingScreenServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILoadingScreenService>().To<LoadingScreenService>().AsSingle();
        }
    }
}
