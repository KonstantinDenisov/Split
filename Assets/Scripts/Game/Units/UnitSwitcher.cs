using System;
using Split.Game.Units.SelectedFolder;
using UnityEngine;
namespace Split.Game.Units
{
    [RequireComponent(typeof(Outline))]
    public class UnitSwitcher : MonoBehaviour
    {
        public bool IsUnderTheCursor;
        public bool IsSelected;
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
            _outline.OutlineWidth = 2;
            IsUnderTheCursor = true;
        }

        public void OnHoverExit()
        {
            _outline.OutlineWidth = 0;
            IsUnderTheCursor = false;
        }
    }
}
