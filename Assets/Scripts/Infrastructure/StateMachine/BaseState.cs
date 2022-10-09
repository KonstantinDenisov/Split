

namespace Split.Infrastructure.StateMachine
{
    public abstract class BaseState : BaseExitableState, IState
    {
        protected BaseState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public abstract void Enter();
    }
}