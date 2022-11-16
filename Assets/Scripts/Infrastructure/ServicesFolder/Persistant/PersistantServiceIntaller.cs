using Zenject;

namespace Split.Infrastructure.ServicesFolder.Persistant
{
    public class PersistantServiceIntaller : Installer<PersistantServiceIntaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPersistantService>().To<PersistantService>().AsSingle();
        }
    }
}