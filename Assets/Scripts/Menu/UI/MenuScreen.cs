using Split.Infrastructure.ServicesFolder.StartLevel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Split.Menu.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _continueButton;

        private IStartLevelService _startLevelService;
        
        [Inject]
        public void Construct(IStartLevelService startLevelService)
        {
            _startLevelService = startLevelService;

        }

        private void Awake()
        {
            _playButton.onClick.AddListener(OnContinueClicked);
            _continueButton.onClick.AddListener(OnPlayButtonClicked);
        }
        
        private void OnPlayButtonClicked()
        {
            _startLevelService.StartGame();
        }  
        private void OnContinueClicked()
        {
            _startLevelService.RestartGame();
        }
        
        

    }
}