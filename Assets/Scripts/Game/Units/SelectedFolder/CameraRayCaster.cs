﻿using System;
using UnityEngine;
using UnityEngine.AI;

namespace Split.Game.Units.SelectedFolder
{
    public class CameraRayCaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _unitLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private LayerMask _interactiveObjects;
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
            
            if (Physics.Raycast(ray, out hit, 100, _interactiveObjects))
            {
                Debug.Log("луч попадает во что-то со слоями из маски");
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();

                if (interactiveObject == null)
                {
                    return;
                }
                Debug.Log("луч попадает в интерактивный объект");
                if (interactiveObject.InteractiveType == InteractiveType.Unit)
                {
                    Debug.Log("луч попадает в юнита");
                    if (_lastUnit == null)
                    {
                        Debug.Log("юнит попал под курсор");
                        var unit = hit.collider.GetComponent<UnitState>();
                        unit.OnHoverEnter();
                        _lastUnit = hit.collider.GetComponent<UnitState>();
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("юнит попал под клик");
                        var unit = hit.collider.GetComponent<UnitState>();
                        unit.OnSelected();
                        SelectedService.Instance.SelectUnit(unit.gameObject); 
                    }
                }

                if (interactiveObject.InteractiveType == InteractiveType.Ground)
                {
                    Debug.Log("луч попал по земле");
                    if (_lastUnit != null)
                    {
                        Debug.Log("юнит вышел из под луча");
                        _lastUnit.OnHoverExit();
                        _lastUnit = null;    
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("клип mouse1 по земле отменяет выделение юнитам");
                        SelectedService.Instance.DeselectAllUnits(); 
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        Debug.Log("клик mouse2 по земле");
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
    }
}