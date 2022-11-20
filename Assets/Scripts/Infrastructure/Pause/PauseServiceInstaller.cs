using Split.Infrastructure.Pause;
using Zenject;

namespace Split.Infrastructure
{
    public class PauseServiceInstaller : Installer<PauseServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPauseService>().To<PauseService>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}