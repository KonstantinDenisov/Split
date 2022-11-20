using Zenject;


namespace Split.Infrastructure.ServicesFolder.InputService
{
    public class SceneLoadServiceInstaller : Installer<SceneLoadServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }
    }
}