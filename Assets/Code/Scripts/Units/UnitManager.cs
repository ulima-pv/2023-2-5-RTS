using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    /*
     - Spawn Unidades X
     - Seleccion Unidad a Instanciar X
     - Seleccionar Unidad / Unidades 
     - Mover Unidades
    */
    private static UnitManager m_Instance;

    private UnitTypeSO m_SelectedUnitTypeToSpawn = null;

    public static UnitManager Instance { 
        get => m_Instance; 
        private set => m_Instance = value; 
    }
    public UnitTypeSO SelectedUnitTypeToSpawn { 
        get => m_SelectedUnitTypeToSpawn; 
        set => m_SelectedUnitTypeToSpawn = value; 
    }

    private void Awake() {
        m_Instance = this;
    }

    public void SpawnUnit(Vector3 position)
    {
        if (SelectedUnitTypeToSpawn == null)
        {
            return;
        }

        Instantiate(
            SelectedUnitTypeToSpawn.prefab,
            position,
            Quaternion.identity
        );
    }

    public void SelectUnit(Vector3 position)
    {
        Debug.Log("Se debe seleccionar una Unidad");
    }
}
