using System.Collections;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.Utility.Coroutine
{
    public interface ICoroutineRunner : IService
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator);
    }
}