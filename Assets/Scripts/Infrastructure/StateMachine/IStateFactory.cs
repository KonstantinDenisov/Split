namespace Split.Infrastructure.StateMachine
{
    public interface IStateFactory
    {
        TState Create<TState>() where TState : class, IExitableState;
    }
}