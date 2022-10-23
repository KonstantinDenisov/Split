using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.ServicesFolder.Npc;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.StateMachine
{
    public static class StateFactory
    {
        public static TState Create<TState>() where TState : class, IExitableState
        {
            return typeof(TState).Name switch
            {
                nameof(BootstrapState) => CreateBootstrapState<TState>(),
                nameof(MenuState) => CreateMenuState<TState>(),
                nameof(GameState) => CreateGameState<TState>(),
                _ => null
            };
        }

        private static TState CreateGameState<TState>() where TState : class, IExitableState
        {
            IGameStateMachine stateMachine = Services.Container.Get<IGameStateMachine>();
            ISceneLoadService sceneLoadService = Services.Container.Get<ISceneLoadService>();
            ILoadingScreenService loadingScreenService = Services.Container.Get<ILoadingScreenService>();
            INpcService npcService = Services.Container.Get<INpcService>();
            IInputService inputService = Services.Container.Get<IInputService>();
            IMissionService missionService = Services.Container.Get<IMissionService>();
            ILevelSettingsService levelSettingsService = Services.Container.Get<ILevelSettingsService>();
            ILevelCompletionService levelCompletionService = Services.Container.Get<ILevelCompletionService>();
            IPersistantService persistantService = Services.Container.Get<IPersistantService>();
            IPauseService pauseService = Services.Container.Get<IPauseService>();
            IUIService uiService = Services.Container.Get<IUIService>();

            return new GameState(stateMachine, sceneLoadService, loadingScreenService, npcService, inputService,
                missionService, levelSettingsService, levelCompletionService, persistantService, pauseService,
                uiService) as TState;
        }

        private static TState CreateMenuState<TState>() where TState : class, IExitableState
        {
            var stateMachine = Services.Container.Get<IGameStateMachine>();

            return new MenuState(stateMachine) as TState;
        }

        private static TState CreateBootstrapState<TState>() where TState : class, IExitableState
        {
            var stateMachine = Services.Container.Get<IGameStateMachine>();
            ILevelSettingsService levelSettingsService =
                Services.Container.Get<ILevelSettingsService>();
            IPersistantService persistantService =
                Services.Container.Get<IPersistantService>();

            return new BootstrapState(stateMachine, levelSettingsService, persistantService) as TState;
        }
    }
}