using System;
using UnityEngine;
using UnityEngine.AI;

namespace Split.Game.Units.SelectedFolder
{
    public class CameraRayCaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _unitLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;
        private Camera _mainCamera;
        private UnitState _lastUnit;
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
            _lastUnit = null;
        }

        private void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100, _unitLayerMask) && _lastUnit == null)
            {
                var unit = hit.collider.GetComponent<UnitState>();
                unit.OnHoverEnter();
                Debug.Log("unit under cursor");
                _lastUnit = unit;
            }
            
            if (Physics.Raycast(ray, out hit, 100, _groundLayerMask) && _lastUnit != null)
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


            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100, _groundLayerMask)) 
            {
                SelectedService.Instance.DeselectAllUnits();
            }

            if (Input.GetMouseButtonDown(1) && (Physics.Raycast(ray, out hit, 100, _groundLayerMask)))
            {
                if (SelectedService.Instance.SelectedUnits != null)
                {
                    foreach (var unit in SelectedService.Instance.SelectedUnits)
                    {
                        _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                        _navMeshAgent.SetDestination(hit.point);
                    } 
                }
            }
        }
    }
}