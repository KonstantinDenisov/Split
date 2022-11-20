using Split.Infrastructure.GameOver;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Zenject;

namespace Split.Infrastructure.Installers
{
    public class GameSceneInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            //LevelSettingsServiceInstaller.Install(Container);
            SceneLoadServiceInstaller.Install(Container);
            LevelCompletionServiceInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
            UIServiceInstaller.Install(Container);
            GameOverServiceInstaller.Install(Container);
        }
    }
}