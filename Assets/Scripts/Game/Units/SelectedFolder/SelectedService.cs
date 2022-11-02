using System.Collections.Generic;
using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    public class SelectedService : MonoBehaviour

    {
        public static SelectedService Instance { get; private set; }
        
        public List<GameObject> AllUnits;
        public List<GameObject> SelectedUnits;

        private void Awake()
        {
            AllUnits = new List<GameObject>();
            SelectedUnits = new List<GameObject>();
            
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = GetComponent<SelectedService>();
            DontDestroyOnLoad(gameObject);
        }

        public void AddUnit(GameObject unit)
        {
            AllUnits.Add(unit);
//            Debug.Log("unit add");
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
            //Debug.Log("unit selected");
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
           // Debug.Log("unit deselected");
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
