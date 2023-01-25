using Split.Infrastructure.StateMachine;

namespace Split.Infrastructure
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IStateFactory _stateFactory;
        private IExitableState _currentState;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Enter<TState>() where TState : class, IState
        {
            ExitCurrent();
            var newState = _stateFactory.Create<TState>();
            newState.Enter();
            _currentState = newState;
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            ExitCurrent();
            var newState = _stateFactory.Create<TState>();
            newState.Enter(payload);
            _currentState = newState;
        }

        private void ExitCurrent()
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
        }
    }
}