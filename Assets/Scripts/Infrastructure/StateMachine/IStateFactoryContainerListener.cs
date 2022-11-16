using Zenject;

namespace Split.Infrastructure.StateMachine
{
    public interface IStateFactoryContainerListener
    {
        void Set(DiContainer diContainer);
    }
}