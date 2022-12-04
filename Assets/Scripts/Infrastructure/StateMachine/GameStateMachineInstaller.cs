using Split.Infrastructure.StateMachine;
using Zenject;

namespace Split.Infrastructure
{
    public class GameStateMachineInstaller : Installer <GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind(typeof(IStateFactory), typeof(IStateFactoryContainerListener)).To<ZenjectStateFactory>()
                .AsSingle();
        }
    }
}