using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    public interface ISelectedService
    {
        void AddUnit(GameObject unit);
        void RemoveUnit(GameObject unit);
        void  SelectUnit(GameObject unit);
        bool IsUnitSelected(GameObject unit);

        void DeselectUnit(GameObject unit);
        void DeselectAllUnits();
        int GetSelectedUnitsQuantity();
        GameObject GetUnitInAllUnits(int i);

    }
}