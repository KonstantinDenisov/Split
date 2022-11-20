using Split.Infrastructure.ServicesFolder.ServicesContainer;
using Split.Infrastructure.ServicesFolder.StartLevel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Split.Menu.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private IStartLevelService _startLevelService;

        [Inject]
        public void Construct(IStartLevelService startLevelService)
        {
            _startLevelService = startLevelService;

        }

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void Start()
        {
           // _startLevelService = Services.Container.Get<IStartLevelService>();
        }

        private void OnPlayButtonClicked()
        {
            _startLevelService.StartGame();
        }
    }
}