using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.StartLevel;
using Split.Infrastructure.Utility.Coroutine;
using Zenject;

namespace Split.Infrastructure.Installers
{
    public class MenuSceneInstaller:MonoInstaller
    {
        public override void InstallBindings()
        {
            //LevelSettingsServiceInstaller.Install(Container);
            LoadingScreenServiceInstaller.Install(Container);
            StartLevelServiceInstaller.Install(Container);
            SceneLoadServiceInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
        }
    }
}