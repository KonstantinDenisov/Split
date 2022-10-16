using System;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.SceneLoader
{
    public interface ISceneLoadService : IService
    {
        void Load(string sceneName, Action completeCallback);
    }
}