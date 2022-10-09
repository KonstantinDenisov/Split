using Split.Infrastructure.Services.ServicesContainer;

namespace Split.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private IExitableState _currentState;

        public void Enter<TState>() where TState : class, IState
        {
            ExitCurrent();
           
            ServicesRegister.RegisterFor<TState>();
            TState newState = StateFactory.Create<TState>(); // new TState();
            newState.Enter();
            _currentState = newState;
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        { 
            ExitCurrent();
            
            ServicesRegister.RegisterFor<TState>();
            TState newState = StateFactory.Create<TState>();
            newState.Enter(payload);
            _currentState = newState;
        }

        private void ExitCurrent()
        {
            if (_currentState != null)
            {
                _currentState.Exit();
                ServicesRegister.UnregisterFor(_currentState.GetType());
            }
        }
    }
}