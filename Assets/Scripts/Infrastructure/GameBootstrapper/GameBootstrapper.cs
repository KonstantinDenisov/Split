using Split.Infrastructure.StateMachine;
using Split.Infrastructure.Services.ServicesContainer;
using UnityEngine;

namespace Split.Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Start()
        {
            GameStateMachine gameStateMachine = new GameStateMachine();
            Services.ServicesContainer.Services.Container.Register<IGameStateMachine>(gameStateMachine);
            
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}
