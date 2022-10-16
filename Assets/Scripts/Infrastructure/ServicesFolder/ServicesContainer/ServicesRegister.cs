using System;
using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.ServicesFolder.Npc;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.ServicesFolder.StartLevel;
using Split.Infrastructure.StateMachine;
using Split.Infrastructure.Utility.Coroutine;

namespace Split.Infrastructure.ServicesFolder.ServicesContainer
{
    public static class ServicesRegister
    {
        public static void RegisterFor<TState>() where TState : class, IExitableState
        {
            Type type = typeof(TState);

            if (type == typeof(BootstrapState))
            {
                RegisterBootstrap();
            }
            else if (type == typeof(MenuState))
            {
                RegisterMenu();
            }
            else if (type == typeof(GameState))
            {
                RegisterGame();
            }
        }

        public static void UnregisterFor(Type type)
        {
            if (type == typeof(GameState))
            {
                UnregisterGame();
            }
            else if (type == typeof(MenuState))
            {
                UnregisterMenu();
            }
        }

        private static void RegisterBootstrap()
        {
            ServicesFolder.ServicesContainer.Services.Container.RegisterMono<ICoroutineRunner>(typeof(CoroutineRunner));
            ServicesFolder.ServicesContainer.Services.Container.Register<ISceneLoadService>(
                new AsyncSceneLoadService(ServicesFolder.ServicesContainer.Services.Container.Get<ICoroutineRunner>()));

            ServicesFolder.ServicesContainer.Services.Container.Register<ILoadingScreenService>(new LoadingScreenService());
            ServicesFolder.ServicesContainer.Services.Container.Register<ILevelSettingsService>(new LevelSettingsService());
            ServicesFolder.ServicesContainer.Services.Container.Register<IPersistantService>(new PersistantService());
        }

        private static void RegisterMenu()
        {
            ILevelSettingsService levelSettingsService = ServicesFolder.ServicesContainer.Services.Container.Get<ILevelSettingsService>();
            IGameStateMachine gameStateMachine = ServicesFolder.ServicesContainer.Services.Container.Get<IGameStateMachine>();
            IPersistantService persistantService = ServicesFolder.ServicesContainer.Services.Container.Get<IPersistantService>();

            ServicesFolder.ServicesContainer.Services.Container.Register<IStartLevelService>(new StartLevelService(levelSettingsService,
                gameStateMachine, persistantService));
        }

        private static void UnregisterMenu()
        {
            ServicesFolder.ServicesContainer.Services.Container.UnRegister<IStartLevelService>();
        }

        private static void RegisterGame()
        {
            ServicesFolder.ServicesContainer.Services.Container.Register<IInputService>(new StandaloneInputService());
            

            

            ILevelSettingsService levelSettingsService = ServicesFolder.ServicesContainer.Services.Container.Get<ILevelSettingsService>();
            IGameStateMachine gameStateMachine = ServicesFolder.ServicesContainer.Services.Container.Get<IGameStateMachine>();

           
        }

        private static void UnregisterGame()
        {
            ServicesFolder.ServicesContainer.Services.Container.UnRegister<IInputService>();
            ServicesFolder.ServicesContainer.Services.Container.UnRegister<INpcService>();
            ServicesFolder.ServicesContainer.Services.Container.UnRegister<IMissionService>();
            ServicesFolder.ServicesContainer.Services.Container.UnRegister<ILevelCompletionService>();
        }
    }
}