using Zenject;

namespace Split.Infrastructure
{
    public class UIServiceInstaller : Installer<UIServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIService>().To<UIService>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}