using System.Collections.Generic;
using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    public class SelectedService : MonoBehaviour, ISelectedService

    {

        public List<GameObject> AllUnits;
        public List<GameObject> SelectedUnits;

        private void Awake()
        {
            AllUnits = new List<GameObject>();
            SelectedUnits = new List<GameObject>();
            
        }

        public void AddUnit(GameObject unit)
        {
            AllUnits.Add(unit);
        }

        public void RemoveUnit(GameObject unit)
        {
            AllUnits.Remove(unit);
        }

        public void SelectUnit(GameObject unit)
        {
            SelectedUnits.Add(unit);
            UnitState unitState = unit.transform.GetComponent<UnitState>();
            unitState.OnSelected();
        }

        public bool IsUnitSelected(GameObject unit)
        {
            return SelectedUnits.Contains(unit);
        }

        public void DeselectUnit(GameObject unit)
        {
            bool isRemoved = SelectedUnits.Remove(unit);
            if (!isRemoved)
                return;
            
            UnitState unitState = unit.transform.GetComponent<UnitState>();
            unitState.OnSelectedExit();
        }

        public void DeselectAllUnits()
        {
            foreach (var unit in SelectedUnits)
            {
                UnitState unitState = unit.transform.GetComponent<UnitState>();
                unitState.OnSelectedExit();
            }
            
            SelectedUnits.Clear();
        }

    }
}
