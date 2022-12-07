﻿using Split.Infrastructure.ServicesFolder.StartLevel;
using UnityEngine;
using Zenject;

namespace Split.Infrastructure.GameWin
{
    public class GameWinService : MonoBehaviour, IGameWinService
    {
        private const string GameWinScreenPath = "GameWinScreen";

        private GameWinScreen _gameWinScreen;
        private IGameWinService _iGameWinService;
        private IStartLevelService _startLevelService;

        [Inject]
        public void Construct(IStartLevelService startLevelService)
        {
            _startLevelService = startLevelService;
        }

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
            _gameWinScreen.OnRestart += RestartGame;
            _gameWinScreen.OnExit += ExitGame;
        }

        private void RestartGame()
        {
            _startLevelService.RestartGame();
        }

        public void Dispose()
        {
            if (_gameWinScreen != null)
            {
                _gameWinScreen.OnExit -= ExitGame;
                _gameWinScreen.OnRestart -= RestartGame;
                Destroy(_gameWinScreen.gameObject);
                _gameWinScreen = null;
            }
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