using UnityEngine;

namespace Split.Infrastructure.GameOver
{
    public class GameOverService : MonoBehaviour, IGameOverService
    {
        private const string GameOverScreenPath = "GameOverScreen";
        
        private GameOverScreen _gameOverScreen;
        private IGameOverService _gameOverServiceImplementation;
        
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
            // _gameOverScreen.OnRestart += RestartGame;
            _gameOverScreen.OnExit += ExitGame;
            //UnitsObserver.OnDead += ActivateGameOver;
        }

        public void Dispose()
        {
            if (_gameOverScreen != null)
            {
                _gameOverScreen.OnExit -= ExitGame;
                //UnitsObserver.OnDead -= ActivateGameOver;
                Destroy(_gameOverScreen.gameObject);
                _gameOverScreen = null;
            }
            // _gameOverScreen.OnRestart -= RestartGame;
        }

        public void ActivateGameOver(bool isActive)
        {
            if(_gameOverScreen==null)
                return;
            _gameOverScreen.gameObject.SetActive(isActive);
        }

        private void ExitGame()
        {
            Exit.ExitButtonClicked();
        }
    }
}