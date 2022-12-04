using Split.Infrastructure.Pause;
using Split.Infrastructure.ServicesFolder.StartLevel;
using UnityEngine;
using Zenject;

namespace Split.Infrastructure.GameOver
{
    public class GameOverService : MonoBehaviour, IGameOverService
    {
        private const string GameOverScreenPath = "GameOverScreen";

        private GameOverScreen _gameOverScreen;
        private IGameOverService _gameOverServiceImplementation;
        private IStartLevelService _startLevelService;
        private IPauseService _pauseService;

        [Inject]
        public void Construct(IStartLevelService startLevelService, IPauseService pauseService)
        {
            _startLevelService = startLevelService;
            _pauseService = pauseService;
        }

        public void Init()
        {
            if (_gameOverScreen == null)
            {
                CreateGameOverScreen();
            }
        }

        private void CreateGameOverScreen()
        {
            GameOverScreen prefab = Resources.Load<GameOverScreen>(GameOverScreenPath);
            _gameOverScreen = Instantiate(prefab);

            _gameOverScreen.gameObject.SetActive(false);
            _gameOverScreen.OnRestart += RestartGame;
            _gameOverScreen.OnExit += ExitGame;
        }

        public void Dispose()
        {
            if (_gameOverScreen != null)
            {
                _gameOverScreen.OnExit -= ExitGame;
                _gameOverScreen.OnRestart -= RestartGame;
                Destroy(_gameOverScreen.gameObject);
                _gameOverScreen = null;
            }
        }

        private void RestartGame()
        {
            _startLevelService.RestartGame();
        }

        public void ActivateGameOver(bool isActive)
        {
            if (_gameOverScreen == null)
                return;
            _gameOverScreen.gameObject.SetActive(isActive);
            _pauseService.IsPauseActive = false;
        }

        private void ExitGame()
        {
            Exit.ExitButtonClicked();
        }
    }
}