using Split.Game.Enemy;
using Split.Infrastructure.GameController;
using Split.Infrastructure.GameOver;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Npc;
using Zenject;
using Zenject.SpaceFighter;

namespace Split.Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
            //MissionServiceInstaller.Install(Container);
            //EnemyRegisterInstaller.Install(Container);
            NpcServiceInstaller.Install(Container);
            LevelCompletionServiceInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
            UIServiceInstaller.Install(Container);
            GameOverServiceInstaller.Install(Container);
            GameControllerInstaller.Install(Container);
        }
    }
}