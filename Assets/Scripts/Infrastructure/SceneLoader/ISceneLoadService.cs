using System;
using Split.Infrastructure.Services.ServicesContainer;

namespace Split.Infrastructure.SceneLoader
{
    public interface ISceneLoadService : IService
    {
        void Load(string sceneName, Action completeCallback);
    }
}