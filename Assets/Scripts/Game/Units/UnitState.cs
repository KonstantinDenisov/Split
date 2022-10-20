using System;
using Split.Game.Units.SelectedFolder;
using UnityEngine;
namespace Split.Game.Units
{
    [RequireComponent(typeof(Outline))]
    public class UnitState : MonoBehaviour
    {
        public bool IsUnderTheCursor;
        public bool IsSelected;
        [SerializeField] private float _widthOutlineOnHover = 1;
        [SerializeField] private float _widthOutlineOnSelected = 3;
        private Outline _outline;
        private void OnEnable()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineWidth = 0;
        }
        private void Start()
        {
            SelectedService.Instance.AddUnit(gameObject);
        }
        public void OnHoverEnter()
        {
            if (IsSelected == true)
                return;
            
            _outline.OutlineWidth = _widthOutlineOnHover;
            IsUnderTheCursor = true;
        }

        public void OnHoverExit()
        {
            if (IsSelected == true)
                return;
            
            _outline.OutlineWidth = 0;
            IsUnderTheCursor = false;
        }

        public void OnSelected ()
        {
            _outline.OutlineWidth = _widthOutlineOnSelected;
            IsSelected = true;
        }

        public void OnSelectedExit()
        {
            _outline.OutlineWidth = 0;
            IsSelected = false;
        }
    }
}
