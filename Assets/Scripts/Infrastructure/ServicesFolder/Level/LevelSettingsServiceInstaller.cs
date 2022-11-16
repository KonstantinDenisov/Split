using Zenject;

namespace Split.Infrastructure.ServicesFolder.Level
{
    public class LevelSettingsServiceInstaller : Installer<LevelSettingsServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelSettingsService>().To<LevelSettingsService>().AsSingle();
        }
    }
}