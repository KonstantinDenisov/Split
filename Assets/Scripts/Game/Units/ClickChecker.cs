using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
namespace Split.Game.Units
{
    public class ClickChecker : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent<Vector3> Onclick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
