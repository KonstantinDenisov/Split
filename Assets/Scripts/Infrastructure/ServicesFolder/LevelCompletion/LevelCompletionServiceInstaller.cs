using Zenject;

namespace Split.Infrastructure.ServicesFolder.LevelCompletion
{
    public class LevelCompletionServiceInstaller : Installer<LevelCompletionServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelCompletionService>().To<LevelCompletionService>().AsSingle();
        }
    }
}