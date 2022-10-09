using UnityEngine;

namespace Split.Game.Enemy
{
    public class EnemyStarter : MonoBehaviour
    {
        [SerializeField] private EnemyIdle _idle;

        public void Begin()
        {
            _idle.Activate();
        }
    }
}