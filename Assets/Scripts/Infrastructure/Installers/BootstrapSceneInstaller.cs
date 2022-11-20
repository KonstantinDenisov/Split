using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.Utility.Coroutine;
using Zenject;

namespace Split.Infrastructure.Installers
{
    public class BootstrapSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            LevelSettingsServiceInstaller.Install(Container);
            LoadingScreenServiceInstaller.Install(Container);
            SceneLoadServiceInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
        }
    }
}