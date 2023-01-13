using UnityEngine;

namespace Split.Game.Units
{
    public class UnitAttackEffect:MonoBehaviour
    {
        [SerializeField] private GameObject _particle;
        [SerializeField] private Transform _transform;
        
        public void SpawnVfx()
        {
            Instantiate(_particle, _transform.position, Quaternion.identity);
        }
    }
}