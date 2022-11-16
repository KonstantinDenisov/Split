using Split.Infrastructure.ServicesFolder.Level;
using Zenject;

namespace Split.Infrastructure.Installers
{
    public class BootstrapSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            LevelSettingsServiceInstaller.Install(Container);
        }
    }
}