using System;

namespace Split.Infrastructure.Services.Persistant
{
    [Serializable]
    public class PersistantPlayerData
    {
        public bool IsSaved;
        public int CurrentHp;
    }
}