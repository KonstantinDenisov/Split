using System;
using System.Collections;
using Split.Infrastructure.Utility.Coroutine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Split.Infrastructure.SceneLoader
{
    public class AsyncSceneLoadService : ISceneLoadService
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public AsyncSceneLoadService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action completeCallback) =>
            _coroutineRunner.StartCoroutine(LoadInternal(sceneName, completeCallback));

        private IEnumerator LoadInternal(string sceneName, Action completeCallback)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
                yield return null;
            
            completeCallback?.Invoke();
        }
    }
}