using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
namespace Split.Game.Units
{
    public class ClickChecker : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("sd");
        }
    }
}
