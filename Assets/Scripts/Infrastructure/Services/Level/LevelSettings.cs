using UnityEngine;

namespace Split.Infrastructure.Services.Level
{
    [CreateAssetMenu(fileName = Tag, menuName = "StaticData/Level")]
    public class LevelSettings: ScriptableObject
    {
        private const string Tag = nameof(LevelSettings);

        [SerializeField] private string _sceneName;
        [SerializeField] private LevelSettings _nextLevel;

        public string SceneName => _sceneName;
        public LevelSettings NextLevel => _nextLevel;
    }
}