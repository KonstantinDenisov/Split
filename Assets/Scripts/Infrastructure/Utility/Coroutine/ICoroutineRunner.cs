using System.Collections;
using Split.Infrastructure.Services.ServicesContainer;

namespace Split.Infrastructure.Utility.Coroutine
{
    public interface ICoroutineRunner : IService
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator);
    }
}