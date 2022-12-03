using Split.Game.Enemy;
using Split.Infrastructure.GameController;
using Split.Infrastructure.GameOver;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Npc;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.StateMachine;

namespace Split.Infrastructure
{
    public class GameState : BaseExitableState, IPayloadState<string>
    {
        private readonly INpcService _npcService;
        private readonly IInputService _inputService;
        //private readonly IMissionService _missionService;
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly ILevelCompletionService _levelCompletionService;
        private readonly IPersistantService _persistantService;
       // private readonly IEnemyRegister _enemyRegister;
        
        private readonly IPauseService _pauseService;
        private readonly ITimerService _timerService;
        private readonly IGameOverService _gameOverService;
        private readonly IGameController _gameController;

        public GameState(IGameStateMachine gameStateMachine, INpcService npcService, IInputService inputService,
            ILevelSettingsService levelSettingsService,
            ILevelCompletionService levelCompletionService, IPersistantService persistantService,
            IPauseService pauseService, ITimerService timerService, IGameOverService gameOverService,
            IGameController gameController) : base(gameStateMachine)
        {
            
        // public GameState(IGameStateMachine gameStateMachine, INpcService npcService, IInputService inputService,
        //     ILevelSettingsService levelSettingsService,
        //     ILevelCompletionService levelCompletionService, IPersistantService persistantService,
        //     IPauseService pauseService, ITimerService timerService, IGameOverService gameOverService,
        //     IGameController gameController,IEnemyRegister enemyRegister) : base(gameStateMachine)
            _npcService = npcService;
            _inputService = inputService;
            //_missionService = missionService;
            _levelSettingsService = levelSettingsService;
            _levelCompletionService = levelCompletionService;
            _persistantService = persistantService;
            _pauseService = pauseService;
            _timerService = timerService;
            _gameOverService = gameOverService;
            _gameController = gameController;
            //_enemyRegister = enemyRegister;
        }

        public void Enter(string sceneName)
        {
           // _levelSettingsService.SetCurrentLevelSettings(sceneName);
            SaveCurrentScene(sceneName);
            Initialize();
            _npcService.Init();
            _pauseService.Init();
            _gameOverService.Init();
            _timerService.Init();
            _gameController.Init();
        }

        public override void Exit()
        {
            Dispose();
        }

        private void SaveCurrentScene(string sceneName)
        {
            PersistantData data = _persistantService.Data;
            data.LevelData.CurrentSceneId = sceneName;
            _persistantService.Save();
        }

        private void Dispose()
        {
          _npcService.Dispose();
           //_missionService.Dispose();
           _levelCompletionService.Dispose();
           _gameOverService.Dispose();
           _pauseService.Dispose();
           _timerService.Dispose();
        }
        

        private void Initialize()
        {
            InitHealth();
        }

        private void InitHealth()
        {
        }

        private void RestartGame()
        {
            Exit();
        }
    }
}