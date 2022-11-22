using Zenject;


namespace Split.Infrastructure.ServicesFolder.InputService
{
    public class InputServiceInstaller : Installer<InputServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }
    }
}