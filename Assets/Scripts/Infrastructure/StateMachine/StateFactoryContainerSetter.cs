using UnityEngine;
using Zenject;

namespace Split.Infrastructure.StateMachine
{
    public class StateFactoryContainerSetter : MonoBehaviour

    {
        [Inject]
        public void Construct(DiContainer diContainer, IStateFactoryContainerListener listener)
        {
            listener.Set(diContainer);
        }
    }
}