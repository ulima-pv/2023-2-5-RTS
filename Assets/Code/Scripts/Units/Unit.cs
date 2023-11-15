using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private UnitTypeSO m_UnitType;
    [SerializeField]
    private Transform m_Selected;

    public void Select()
    {
        m_Selected.gameObject.SetActive(!m_Selected.gameObject.activeSelf);
    }
}
