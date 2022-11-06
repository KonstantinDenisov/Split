using System;
using UnityEngine;
using UnityEngine.UI;

namespace Split.Infrastructure.GameOver
{
    public class GameOverScreen : MonoBehaviour
    {
        //[SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        //public event Action OnRestart;
        public event Action OnExit;

        private void Start()
        {
            //_restartButton.onClick.AddListener(delegate { OnRestart?.Invoke(); });
            _exitButton.onClick.AddListener(delegate { OnExit?.Invoke(); });
        }
    }
}