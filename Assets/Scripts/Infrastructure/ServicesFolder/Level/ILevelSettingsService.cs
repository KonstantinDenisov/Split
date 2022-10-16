using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.ServicesFolder.Level
{
    public interface ILevelSettingsService : IService
    {
        void Bootstrap();
        void SetCurrentLevelSettings(string id);
        LevelSettings GetCurrentLevelSetting();
        LevelSettings GetFirstLevelSettings();
        LevelSettings GetLevelSettings(string id);
    }
}