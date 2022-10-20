using Split.Game.Units;
using UnityEngine;

namespace Split.Game.WithFasade
{
    public class CameraRayCasterWithFasade : MonoBehaviour
    {
        private Camera _mainCamera;
        private UnitFacade _lastUnit;

        private void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                var unit = hit.collider.GetComponent<UnitFacade>();
                if (unit != null)
                {
                    if (unit != _lastUnit)
                    {
                        unit.unitState.OnHoverEnter();
                        Debug.Log("unit under cursor");
                        _lastUnit = unit;
                    }
                    
                }
            }
            else if (_lastUnit != null) 
                /* вот тут почему-то не работает.
                 логика такая: 
                 если курсор не наведён на юнит и при этом есть какой-то последний юнит - то его нужно обнулить. 
                 убирается курсор - пропадает подсветка.
                 для того, чтобы этот Log срабатывал, приходится убирать курсор в угол экрана. 
                 даже не в угол игрового экрана. а в угол экрана 32"
                 я бы это показал через запись экрана но на записи экрана не виден курсор
            */
            
            {
                Debug.Log("the unit went out from under the cursor");
                _lastUnit.unitState.OnHoverExit();
                _lastUnit = null;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    var unit = hit.collider.GetComponent<UnitFacade>();
                    if (unit != null)
                    {
                        unit.unitState.OnSelected();
                        SelectedServiceWithFasade.Instance.SelectUnit(unit.gameObject);
                    }
                }
            }
            
            else if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    var ground = hit.collider.GetComponent<Ground>();
                    if (ground != null)
                    {
                        SelectedServiceWithFasade.Instance.DeselectAllUnits();
                    }
                }
            }

            else if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    var ground = hit.collider.GetComponent<Ground>();
                    if (ground != null && SelectedServiceWithFasade.Instance.SelectedUnits != null)
                    {
                        foreach (var unit in SelectedServiceWithFasade.Instance.SelectedUnits)
                        {
                            // направить в точку клика 
                        }
                    }
                }
            }
        }
    }
}