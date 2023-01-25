using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.Persistant
{
    public class PersistantService : IPersistantService
    {
        private const string Key = "Persistant/PersistantData";
        
        public PersistantData Data { get; private set; }
        
        public void Bootstrap()
        {
            var json = PlayerPrefs.GetString(Key);

            if (string.IsNullOrEmpty(json))
            {
                Data = new PersistantData();
            }
            else
            {
                try
                {
                    Data = JsonUtility.FromJson<PersistantData>(json);
                }
                catch 
                {
                    Data = new PersistantData();
                }
            }
        }

        public void Save()
        {
            var json = JsonUtility.ToJson(Data);
            PlayerPrefs.SetString(Key, json);
        }
    }
}