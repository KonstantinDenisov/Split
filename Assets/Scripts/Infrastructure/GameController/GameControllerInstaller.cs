using Zenject;

namespace Split.Infrastructure.GameController
{
    public class GameControllerInstaller : Installer<GameControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameController>().To<Infrastructure.GameController.GameController>().AsSingle();
        }
    }
}