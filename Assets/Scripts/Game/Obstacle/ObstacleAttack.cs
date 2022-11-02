using Split.Game.Units;
using UnityEngine;

namespace Split.Game.Obstacle
{
    public class ObstacleAttack : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        
        private void OnTriggerEnter(Collider col)
        {

            if (col.gameObject.CompareTag(Tags.Unit))
            { 
                UnitHp unitHp = col.gameObject.GetComponent<UnitHp>();
                unitHp.ApplyDamage(_damage);
            }
        }
    }
}