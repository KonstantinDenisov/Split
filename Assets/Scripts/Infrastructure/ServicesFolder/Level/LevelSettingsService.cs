using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.Level
{
    public class LevelSettingsService : ILevelSettingsService
    {
        private const string SettingsPath = "StaticData/Level/LevelSettingsContainer";
        
        private LevelSettingsContainer _container;
        private string _currentLevelId;
        
        public void Bootstrap()
        {
            _container = Resources.Load<LevelSettingsContainer>(SettingsPath);
        }

        public void SetCurrentLevelSettings(string id)
        {
            _currentLevelId = id;
        }

        public LevelSettings GetCurrentLevelSetting() =>
            GetLevelSettings(_currentLevelId);

        public LevelSettings GetFirstLevelSettings() =>
            _container.GetFirstLevelSettings();

        public LevelSettings GetLevelSettings(string id) =>
            _container.GetSettings(id);
    }
}