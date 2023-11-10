using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    /*
     - Spawn Unidades
     - Seleccionar Unidad / Unidades
     - Mover Unidades
    */

    private UnitTypeSO m_SelectedUnitTypeToSpawn = null;

    public void SpawnUnit(Vector3 position)
    {
        if (m_SelectedUnitTypeToSpawn == null)
        {
            return;
        }

        //...
    }
}
