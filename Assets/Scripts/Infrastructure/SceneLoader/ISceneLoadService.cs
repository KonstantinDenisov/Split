using System;

namespace Split.Infrastructure.SceneLoader
{
    public interface ISceneLoadService 
    {
        void Load(string sceneName, Action completeCallback);
    }
}