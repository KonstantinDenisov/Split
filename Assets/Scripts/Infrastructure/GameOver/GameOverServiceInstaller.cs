using Zenject;

namespace Split.Infrastructure.GameOver
{
    public class GameOverServiceInstaller : Installer<GameOverServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameOverService>().To<GameOverService>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}