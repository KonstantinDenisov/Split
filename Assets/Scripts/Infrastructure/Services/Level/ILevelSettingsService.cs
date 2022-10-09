using Split.Infrastructure.Services.ServicesContainer;


namespace Split.Infrastructure.Services.Level
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