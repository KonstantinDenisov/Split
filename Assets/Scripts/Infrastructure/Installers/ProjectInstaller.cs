using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.ServicesFolder.StartLevel;
using Split.Infrastructure.StateMachine;
using Split.Infrastructure.Utility.Coroutine;
using Zenject;

namespace Split.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameStateMachineInstaller.Install(Container);
            LevelSettingsServiceInstaller.Install(Container);
            PersistantServiceIntaller.Install(Container);
            SceneLoadServiceInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
            LoadingScreenServiceInstaller.Install(Container);
            StartLevelServiceInstaller.Install(Container);
        }
        
    }
}