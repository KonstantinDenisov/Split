using System;
using UnityEngine;
using UnityEngine.UI;

namespace Split.Infrastructure
{
    public class PauseScreen:MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        
        public event Action OnContinue;
        public event Action OnRestart;
        public event Action OnExit;

        private void Start()
        {
            _continueButton.onClick.AddListener(delegate { OnContinue?.Invoke(); });
            _restartButton.onClick.AddListener(delegate { OnRestart?.Invoke(); });
            _exitButton.onClick.AddListener(delegate { OnExit?.Invoke(); });
        }

        public event Action OnRestarted;
        public void Init()
        {
        }
    }
}