using UnityEngine;

namespace Split.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private void OnTriggerEnter(Collider col)
        {
            ExplosionDamage();
        }

        private void ExplosionDamage()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);
            foreach (var hitCollider in hitColliders)
            {
                hitCollider.SendMessage("AddDamage");
            }
        }
    }
}