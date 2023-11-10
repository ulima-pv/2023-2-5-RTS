using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUnitBar : MonoBehaviour
{
    [SerializeField]
    private List<UnitTypeSO> m_UnitTypeList;
    [SerializeField]
    private GameObject prefabUIUnitItem;

    public List<UnitTypeSO> UnitTypeList { 
        get => m_UnitTypeList; 
        set => m_UnitTypeList = value; 
    }

    private void Start() 
    {
        foreach (var unitType in m_UnitTypeList)
        {
            var unitItem = Instantiate(
                prefabUIUnitItem, 
                Vector3.zero, 
                Quaternion.identity, transform
            );
            unitItem.GetComponent<UIUnitItem>().Init(
                unitType.unitName,
                () => {
                    // Codigo Que se va a ejecutar al presionar el boton
                    UnitManager.Instance.SelectedUnitTypeToSpawn = unitType;
                }
            );

        }
    }
}
