using Zenject;

namespace Split.Infrastructure.UnitRegisterService
{
    public class UnitRegisterServiceInstaller : Installer<UnitRegisterServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUnitRegisterService>().To<UnitRegisterService>().AsSingle();
        }
    }
}