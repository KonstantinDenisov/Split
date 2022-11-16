using Zenject;

namespace Split.Infrastructure.StateMachine
{
    public class ZenjectStateFactory : IStateFactory, IStateFactoryContainerListener
    {
        private DiContainer _container;

        public ZenjectStateFactory(DiContainer container)
        {
            _container = container;
        }
        
        public TState Create<TState>() where TState : class, IExitableState
        {
            return _container.Instantiate<TState>();
        }

        public void Set(DiContainer diContainer)
        {
            _container = diContainer;
        }
    }
}