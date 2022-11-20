using Zenject;

namespace Split.Infrastructure.Utility.Coroutine
{
    public class CoroutineRunnerInstaller : Installer<CoroutineRunnerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}