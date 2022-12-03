using Split.Game.Units;
using UnityEngine;

namespace Split.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _unitDamage = 1;
        [SerializeField] private int _enemyDamage = 1;

        private bool _isExplode;

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag(Tags.Unit) && !_isExplode)
            {
                ExplosionDamage();
                //PlayAnimation();
            }
        }

        private void ExplosionDamage()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.TryGetComponent(out UnitHp unit))
                {
                    unit.ApplyDamage(_unitDamage);
                }
            }

            _isExplode = true;
            _enemyHp.RemoveHp(_enemyDamage);
        }
    }
}