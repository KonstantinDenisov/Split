using System.Collections.Generic;
using Split.Game.Units;
using Split.Game.Units.SelectedFolder;
using UnityEngine;

namespace Split.Game.WithFasade
{
    public class SelectedServiceWithFasade : MonoBehaviour

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
            Debug.Log("unit add");
        }

        public void SelectUnit(GameObject unit)
        {
            SelectedUnits.Add(unit);
            UnitFacade unitFacade = unit.transform.GetComponent<UnitFacade>();
            unitFacade.UnitSwitcher.OnSelected();
            Debug.Log("unit selected");
        }

        public void DeselectAllUnits()
        {
            foreach (var unit in SelectedUnits)
            {
                UnitFacade unitFacade = unit.transform.GetComponent<UnitFacade>();
                unitFacade.UnitSwitcher.OnSelectedExit();
            }
            
            SelectedUnits.Clear();
            Debug.Log("all units deselect");
        }

    }
}
