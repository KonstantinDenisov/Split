using System.Collections.Generic;
using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    public class SelectedService : MonoBehaviour

    {
        public static SelectedService Instance { get; private set; }
        
        public static List<GameObject> AllUnits;
        public static List<GameObject> SelectedUnits;

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
            Debug.Log("unit selected");
        }

        public void DeselectAllUnits()
        {
            SelectedUnits.Clear();
            Debug.Log("all units deselect");
        }

    }
}
