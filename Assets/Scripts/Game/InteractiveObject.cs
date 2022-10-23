using UnityEngine;

namespace Split.Game
{
    public class InteractiveObject : MonoBehaviour
    {
        [SerializeField] private InteractiveType _interactiveType;

        public InteractiveType InteractiveType => _interactiveType;
    }
}