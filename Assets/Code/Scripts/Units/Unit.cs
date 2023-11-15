using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private UnitTypeSO m_UnitType;
    [SerializeField]
    private Transform m_Selected;

    private bool m_IsSelected = false;

    public bool IsSelected { 
        get => m_IsSelected; 
        private set => m_IsSelected = value; 
    }

    public void Select()
    {
        m_IsSelected = !m_IsSelected;
        m_Selected.gameObject.SetActive(!m_Selected.gameObject.activeSelf);
    }
}
