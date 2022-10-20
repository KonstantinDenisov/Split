using System;
using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    public class CameraRayCaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _unitLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;
        private Camera _mainCamera;
        private UnitState _lastUnit;

        private void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100, _unitLayerMask))
            {
                var unit = hit.collider.GetComponent<UnitState>();
                
                if (unit != _lastUnit)
                    {
                        unit.OnHoverEnter();
                        Debug.Log("unit under cursor");
                        _lastUnit = unit;
                    }
            }
            
            else if (_lastUnit != null)
            {
                Debug.Log("the unit went out from under the cursor");
                _lastUnit.OnHoverExit();
                _lastUnit = null;
            }
            
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100, _unitLayerMask))
            {
                    var unit = hit.collider.GetComponent<UnitState>();
                    unit.OnSelected();
                    SelectedService.Instance.SelectUnit(unit.gameObject);
            }


            else if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100, _groundLayerMask)) 
            {
                var ground = hit.collider.GetComponent<Ground>();
                SelectedService.Instance.DeselectAllUnits();
            }

            if (Input.GetMouseButtonDown(1) && (Physics.Raycast(ray, out hit, 100, _groundLayerMask)))
            {
                var ground = hit.collider.GetComponent<Ground>();
                    if (SelectedService.Instance.SelectedUnits != null)
                    {
                        foreach (var unit in SelectedService.Instance.SelectedUnits)
                        {
                            // направить в точку клика 
                        }
                    }
            }
        }
    }
}