using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Split.Infrastructure.Services.ServicesContainer
{
    public class Services
    {
        private const string Tag = nameof(Services);

        private readonly Dictionary<Type, IService> _services = new();
        private readonly Dictionary<Type, Component> _components = new();
        private static Services _container;

        public static Services Container => _container ??= new Services();
        
        public TService Register<TService>(TService implementation) where TService : class, IService
        {
            Type key = typeof(TService);

            if (_services.ContainsKey(key))
            {
                Debug.LogError($"{Tag}:{nameof(Register)}: Try add service with key '{key}', that already exist.");
                return null;
            }

            _services.Add(key, implementation);
            return implementation;
        }

        public TService RegisterMono<TService>(Type serviceType) where TService : class, IService
        {
            Component service = new GameObject(serviceType.Name).AddComponent(serviceType);
            Object.DontDestroyOnLoad(service);
            _components.Add(typeof(TService), service);
            return Register<TService>(service as TService);
        }

        public TService Get<TService>() where TService : class, IService
        {
            Type key = typeof(TService);

            if (_services.ContainsKey(key))
            {
                return _services[key] as TService;
            }

            Debug.LogError($"{Tag}:{nameof(Get)}: There is no service with key '{key}'.");
            return default;
        }

        public void Get<TService>(out TService service) where TService : class, IService =>
            service = Get<TService>();

        public void UnRegister<TService>() where TService : IService
        {
            Type key = typeof(TService);
            if (!_services.ContainsKey(key))
            {
                Debug.LogError(
                    $"{Tag}:{nameof(UnRegister)}: Try remove service with key '{key}', that already removed.");
                return;
            }

            _services.Remove(key);

            if (_components.ContainsKey(key))
            {
                Component serviceComponent = _components[key];
                Object.Destroy(serviceComponent.gameObject);
                _components.Remove(key);
            }
        }
        
        public void UnRegisterAndNullRef<TService>(ref TService service) where TService : class, IService
        {
            UnRegister<TService>();
            service = null;
        }
    }
}