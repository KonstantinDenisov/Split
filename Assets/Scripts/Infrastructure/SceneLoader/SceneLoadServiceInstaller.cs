using Zenject;

namespace Split.Infrastructure.SceneLoader
{
    public class SceneLoadServiceInstaller : Installer<SceneLoadServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoadService>().To<AsyncSceneLoadService>().AsSingle();
        }
    }
}