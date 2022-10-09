using Split.Infrastructure.Services.Level;
using Split.Infrastructure.Services.Persistant;
using Split.Infrastructure.StateMachine;

namespace Split.Infrastructure.Services.StartLevel
{
    public class StartLevelService : IStartLevelService
    {
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly IGameStateMachine _stateMachine;
        private readonly IPersistantService _persistantService;

        public StartLevelService(ILevelSettingsService levelSettingsService, IGameStateMachine stateMachine,
            IPersistantService persistantService)
        {
            _levelSettingsService = levelSettingsService;
            _stateMachine = stateMachine;
            _persistantService = persistantService;
        }

        public void StartGame()
        {
            PersistantData data = _persistantService.Data;
            if(string.IsNullOrEmpty(data.LevelData.CurrentSceneId))
            {
                LevelSettings firstLevelSettings = _levelSettingsService.GetFirstLevelSettings();
                _stateMachine.Enter<GameState, string>(firstLevelSettings.SceneName);    
            }
            else
            {
                LevelSettings savedSettings = _levelSettingsService.GetLevelSettings(data.LevelData.CurrentSceneId);
                _stateMachine.Enter<GameState, string>(savedSettings.SceneName);    
            }
        }
    }
}