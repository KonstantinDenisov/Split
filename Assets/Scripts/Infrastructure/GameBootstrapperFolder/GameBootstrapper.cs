using Split.Infrastructure.StateMachine;
using UnityEngine;

namespace Split.Infrastructure.GameBootstrapperFolder
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Start()
        {
            GameStateMachine gameStateMachine = new GameStateMachine();
            ServicesFolder.ServicesContainer.Services.Container.Register<IGameStateMachine>(gameStateMachine);
            
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}
