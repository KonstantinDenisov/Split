using System;

namespace Split.Infrastructure.ServicesFolder.Persistant
{
    [Serializable]
    public class PersistantData
    {
        public PersistantLevelData LevelData;
        public PersistantPlayerData PlayerData;

        public PersistantData()
        {
            LevelData = new PersistantLevelData();
            PlayerData = new PersistantPlayerData();
        }
    }
}