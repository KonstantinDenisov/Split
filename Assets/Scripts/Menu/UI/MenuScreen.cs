using Split.Infrastructure.Services.ServicesContainer;
using Split.Infrastructure.Services.StartLevel;
using UnityEngine;
using UnityEngine.UI;

namespace Split.Menu.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private IStartLevelService _startLevelService;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void Start()
        {
            _startLevelService = Services.Container.Get<IStartLevelService>();
        }

        private void OnPlayButtonClicked()
        {
            _startLevelService.StartGame();
        }
    }
}