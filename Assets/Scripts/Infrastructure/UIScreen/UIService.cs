using UnityEngine;

namespace Split.Infrastructure
{
    public class UIService : MonoBehaviour, IUIService
    {
        private const string GameStateScreenPath = "GameStateScreen";

        private UIScreen _uiScreen;

        public void Init()
        {
            if (_uiScreen != null)
            {
            }

            CreateUIScreen();
        }

        private void CreateUIScreen()
        {
            UIScreen prefab = Resources.Load<UIScreen>(GameStateScreenPath);
            _uiScreen = Instantiate(prefab);

            _uiScreen.gameObject.SetActive(true);

            _uiScreen.BeginTimer();
        }

        public void Dispose()
        {
            if (_uiScreen == null)
            {
            }

            _uiScreen.ResetTimer();
            Destroy(_uiScreen.gameObject);
            _uiScreen = null;
        }
    }
}