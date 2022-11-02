/*using Split.Game.Units.Shared;
using UnityEngine;

namespace Split.Game.Units
{
    public class UnitAttack : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _radius = 10;

        private float _timer;
        private bool _isExplosed;

        private void Update()
        {
            TickTimer();

            //if (_timer <= 0 && _isExplosed)
            // LeanPool.Despawn(gameObject);
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag(Tags.Obstacle))
            {
                //_timer = 2f;
                //_isExplosed = true;
                //Explode();
                Debug.Log("It's work");
                IHealth health = col.GetComponentInParent<IHealth>();
                health.ApplyDamage(_damage);
            }
        }

        private void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (Collider col in colliders)
            {
                IHealth health = col.GetComponentInParent<IHealth>();
                if (health != null)
                {
                    health.ApplyDamage(_damage);
                    
                }
            }
        }

        private void TickTimer() =>
            _timer -= Time.deltaTime;
    }
}*/