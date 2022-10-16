using Split.Game.Units.SelectedFolder;
using UnityEngine;

namespace Split.Game
{
    public class Ground : MonoBehaviour
    {
        private void OnMouseDown()
        {
            SelectedService.Instance.DeselectAllUnits();
        }
    }
}
