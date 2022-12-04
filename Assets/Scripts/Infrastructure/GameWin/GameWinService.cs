using UnityEngine;

namespace Split.Infrastructure.GameWin
{
    public class GameWinService : MonoBehaviour, IGameWinService
    {
        private const string GameWinScreenPath = "GameWinScreen";

        private GameWinScreen _gameWinScreen;
        private IGameWinService _iGameWinService;

        public void Init()
        {
            if (_gameWinScreen == null)
            {
                CreateGameOverScreen();
            }
        }

        private void CreateGameOverScreen()
        {
            GameWinScreen prefab = Resources.Load<GameWinScreen>(GameWinScreenPath);
            _gameWinScreen = Instantiate(prefab);

            _gameWinScreen.gameObject.SetActive(false);
            // _gameOverScreen.OnRestart += RestartGame;
            _gameWinScreen.OnExit += ExitGame;
            //UnitsObserver.OnDead += ActivateGameOver;
        }

        public void Dispose()
        {
            if (_gameWinScreen != null)
            {
                _gameWinScreen.OnExit -= ExitGame;
                //UnitsObserver.OnDead -= ActivateGameOver;
                Destroy(_gameWinScreen.gameObject);
                _gameWinScreen = null;
            }
            // _gameOverScreen.OnRestart -= RestartGame;
        }

        public void ActivateGameWin(bool isActive)
        {
            if (_gameWinScreen == null)
                return;
            _gameWinScreen.gameObject.SetActive(isActive);
        }

        private void ExitGame()
        {
            Exit.ExitButtonClicked();
        }
    }
}