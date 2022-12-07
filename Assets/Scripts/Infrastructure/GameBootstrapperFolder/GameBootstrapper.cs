using Split.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Split.Infrastructure.GameBootstrapperFolder
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}