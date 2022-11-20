using System.Collections;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.Utility.Coroutine
{
    public interface ICoroutineRunner
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator);
    }
}