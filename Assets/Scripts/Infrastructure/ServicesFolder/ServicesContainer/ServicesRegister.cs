using System;
using Split.Infrastructure.Pause;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
// using Split.Infrastructure.ServicesFolder.Mission;
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
            var type = typeof(TState);

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
        { //Services.Container.RegisterMono<ICoroutineRunner>(typeof(CoroutineRunner));
           // Services.Container.Register<ISceneLoadService>(
                //new AsyncSceneLoadService(Services.Container.Get<ICoroutineRunner>()));

                //Services.Container.Register<ILoadingScreenService>(new LoadingScreenService());
            //Services.Container.Register<ILevelSettingsService>(new LevelSettingsService());
          // Services.Container.Register<IPersistantService>(new PersistantService());
        }

        private static void RegisterMenu()
        {
            //ILevelSettingsService levelSettingsService =
              //  Services.Container.Get<ILevelSettingsService>();
            var gameStateMachine =
                Services.Container.Get<IGameStateMachine>();
            var persistantService =
                Services.Container.Get<IPersistantService>();

            //Services.Container.Register<IStartLevelService>(new StartLevelService(
              //  levelSettingsService,
                //gameStateMachine, persistantService));
        }

        private static void UnregisterMenu()
        {
            //Services.Container.UnRegister<IStartLevelService>();
        }

        private static void RegisterGame()
        {
            //Services.Container.Register<IInputService>(new StandaloneInputService());
            //Services.Container.Get<ILevelSettingsService>();
            Services.Container.Get<IGameStateMachine>();
           // Services.Container.RegisterMono<IPauseService>(typeof(PauseService));
            //Services.Container.RegisterMono<IUIService>(typeof(UIService));
           // Services.Container.RegisterMono<IGameOverService>(typeof(GameOverService));
        }

        private static void UnregisterGame()
        {
            //Services.Container.UnRegister<IInputService>();
            //Services.Container.UnRegister<INpcService>();
            //Services.Container.UnRegister<IMissionService>();
            //Services.Container.UnRegister<ILevelCompletionService>();
           // Services.Container.UnRegister<IPauseService>();
           // Services.Container.UnRegister<IUIService>();
            //Services.Container.UnRegister<IGameOverService>();
        }
    }
}