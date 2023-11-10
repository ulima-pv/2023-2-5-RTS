using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIUnitItem : MonoBehaviour
{
    /*
    * TODO: Gestionar colores cuando se encuentra seleccionado
    *       una unidad.
    */
    [SerializeField]
    private TextMeshProUGUI m_Text;

    private Button m_But;

    private void Awake() 
    {
        m_But = GetComponent<Button>();
    }

    public void Init(string unitName, UnityAction listener)
    {
        m_Text.text = unitName;
        m_But.onClick.AddListener(listener);
    }
}
