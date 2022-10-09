using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.Services.InputService;
using Split.Infrastructure.Services.Level;
using Split.Infrastructure.Services.LevelCompletion;
using Split.Infrastructure.Services.Mission;
using Split.Infrastructure.Services.Npc;
using Split.Infrastructure.Services.Persistant;

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
            IGameStateMachine stateMachine = Services.ServicesContainer.Services.Container.Get<IGameStateMachine>();
            ISceneLoadService sceneLoadService = Services.ServicesContainer.Services.Container.Get<ISceneLoadService>();
            ILoadingScreenService loadingScreenService = Services.ServicesContainer.Services.Container.Get<ILoadingScreenService>();
            INpcService npcService = Services.ServicesContainer.Services.Container.Get<INpcService>();
            IInputService inputService = Services.ServicesContainer.Services.Container.Get<IInputService>();
            IMissionService missionService = Services.ServicesContainer.Services.Container.Get<IMissionService>();
            ILevelSettingsService levelSettingsService = Services.ServicesContainer.Services.Container.Get<ILevelSettingsService>();
            ILevelCompletionService levelCompletionService = Services.ServicesContainer.Services.Container.Get<ILevelCompletionService>();
            IPersistantService persistantService = Services.ServicesContainer.Services.Container.Get<IPersistantService>();

            return new GameState(stateMachine, sceneLoadService, loadingScreenService, npcService, inputService,
                missionService, levelSettingsService, levelCompletionService, persistantService) as TState;
        }

        private static TState CreateMenuState<TState>() where TState : class, IExitableState
        {
            var stateMachine = Services.ServicesContainer.Services.Container.Get<IGameStateMachine>();

            return new MenuState(stateMachine) as TState;
        }

        private static TState CreateBootstrapState<TState>() where TState : class, IExitableState
        {
            var stateMachine = Services.ServicesContainer.Services.Container.Get<IGameStateMachine>();
            ILevelSettingsService levelSettingsService = Services.ServicesContainer.Services.Container.Get<ILevelSettingsService>();
            IPersistantService persistantService = Services.ServicesContainer.Services.Container.Get<IPersistantService>();

            return new BootstrapState(stateMachine, levelSettingsService, persistantService) as TState;
        }
    }
}