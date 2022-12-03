using Zenject;

namespace Split.Infrastructure.ServicesFolder.Npc
{
    public class NpcServiceInstaller: Installer<NpcServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<INpcService>().To<NpcService>().AsSingle();
        }
    }
}
