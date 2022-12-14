using Split.Game.Units;
using UnityEngine;

namespace Split.Game.Obstacle
{
    public class ObstacleThreat: MonoBehaviour
    {
        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag(Tags.Unit))
            { 
                UnitUiActivate unitHp = col.gameObject.GetComponent<UnitUiActivate>();
                unitHp.Activate();
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