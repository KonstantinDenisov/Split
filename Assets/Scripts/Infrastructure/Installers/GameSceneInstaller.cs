using Split.Game.Units.SelectedFolder;
using Split.Infrastructure.GameController;
using Split.Infrastructure.GameOver;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Npc;
using Split.Infrastructure.UnitRegisterService;
using Zenject;

namespace Split.Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
            NpcServiceInstaller.Install(Container);
            LevelCompletionServiceInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
            UIServiceInstaller.Install(Container);
            GameOverServiceInstaller.Install(Container);
            GameControllerInstaller.Install(Container);
            UnitRegisterServiceInstaller.Install(Container);
            WinServiceInstaller.Install(Container);
            SelectedServiceInstaller.Install(Container);
            //CameraRayCasterInstaller.Install(Container);
        }
    }
}