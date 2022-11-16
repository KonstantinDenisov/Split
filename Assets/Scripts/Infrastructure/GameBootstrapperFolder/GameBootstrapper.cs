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
            //GameStateMachine gameStateMachine = new GameStateMachine();
            //ServicesFolder.ServicesContainer.Services.Container.Register<IGameStateMachine>(gameStateMachine);
            
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
