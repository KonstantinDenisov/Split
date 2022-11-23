using Split.Infrastructure.GameOver;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.ServicesFolder.Mission.KillOneEnemy;
using Zenject;

namespace Split.Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
            //MissionServiceInstaller.Install(Container);
            LevelCompletionServiceInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
            UIServiceInstaller.Install(Container);
            GameOverServiceInstaller.Install(Container);
        }
    }
}