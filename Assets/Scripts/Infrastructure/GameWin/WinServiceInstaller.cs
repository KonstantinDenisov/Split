using Split.Infrastructure.GameWin;
using Zenject;

namespace Split.Infrastructure
{
    public class WinServiceInstaller: Installer<WinServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameWinService >().To<GameWinService >().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}
