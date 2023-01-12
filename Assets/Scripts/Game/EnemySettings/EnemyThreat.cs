using Split.Game.Units;
using UnityEngine;

namespace Split.Game.EnemySettings
{
    public class EnemyThreat : MonoBehaviour
    {
        private void OnTriggerEnter(Collider col)
        {
            Debug.Log("EnemyThreat");
            if (col.gameObject.CompareTag(Tags.Unit))
            {
                UnitUiActivate unitHp = col.gameObject.GetComponent<UnitUiActivate>();
                unitHp.Activate();
                Debug.Log("IF EnemyThreat");
            }
            
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.gameObject.CompareTag(Tags.Unit))
            {
                UnitUiActivate unitHp = col.gameObject.GetComponent<UnitUiActivate>();
                unitHp.Diactivate();
            }
        }
    }
}