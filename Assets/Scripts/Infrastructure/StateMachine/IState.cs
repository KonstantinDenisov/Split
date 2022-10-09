namespace Split.Infrastructure.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}