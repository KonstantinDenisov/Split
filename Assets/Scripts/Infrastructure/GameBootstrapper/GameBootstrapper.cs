using Split.Infrastructure.Services.ServicesContainer;
using Split.Infrastructure.StateMachine;
using UnityEngine;

namespace Split.Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log($"Start In GameBootstrapper");

            GameStateMachine gameStateMachine = new GameStateMachine();
            Split.Infrastructure.Services.ServicesContainer.Services.Container.Register<IGameStateMachine>(gameStateMachine);
            
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}
