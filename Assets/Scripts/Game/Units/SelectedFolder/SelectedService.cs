using System.Collections.Generic;
using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    public class SelectedService : MonoBehaviour, ISelectedService

    {
        #region Variables

        private List<GameObject> _allUnits;
        private List<GameObject> _selectedUnits;

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _allUnits = new List<GameObject>();
            _selectedUnits = new List<GameObject>();
        }

        #endregion


        #region Public Methods

        public void AddUnit(GameObject unit)
        {
            _allUnits.Add(unit);
        }

        public void RemoveUnit(GameObject unit)
        {
            _allUnits.Remove(unit);
        }

        public void SelectUnit(GameObject unit)
        {
            _selectedUnits.Add(unit);
            UnitState unitState = unit.transform.GetComponent<UnitState>();
            unitState.OnSelected();
        }

        public bool IsUnitSelected(GameObject unit)
        {
            return _selectedUnits.Contains(unit);
        }

        public void DeselectUnit(GameObject unit)
        {
            bool isRemoved = _selectedUnits.Remove(unit);
            if (!isRemoved)
                return;
            
            UnitState unitState = unit.transform.GetComponent<UnitState>();
            unitState.OnSelectedExit();
        }

        public void DeselectAllUnits()
        {
            foreach (var unit in _selectedUnits)
            {
                UnitState unitState = unit.transform.GetComponent<UnitState>();
                unitState.OnSelectedExit();
            }
            
            _selectedUnits.Clear();
        }
        
        public int GetSelectedUnitsQuantity()
        {
            int selectedUnitsQuantity = _selectedUnits.Count;
            return selectedUnitsQuantity;
        }

        public GameObject GetUnitInAllUnits(int i)
        {
            GameObject unit = _allUnits[i];
            return unit;
        }

        #endregion
    }
}
