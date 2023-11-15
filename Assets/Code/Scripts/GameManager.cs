using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum GameMode
{
    Selection, UnitSpawn
}

public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;

    private GameMode m_Mode = GameMode.Selection;

    public static GameManager Instance { 
        get => m_Instance; 
        private set => m_Instance = value; 
    }
    public GameMode Mode { 
        get => m_Mode; 
        set => m_Mode = value; 
    }

    private void Awake() 
    {
        m_Instance = this;
    }

    public void Select(Vector3 position, GameObject collision)
    {
        if (m_Mode == GameMode.UnitSpawn)
        {
            UnitManager.Instance.SpawnUnit(position);
        }else
        {
            Debug.Log(collision.name);
            var unit = collision.GetComponent<Unit>();
            if (unit != null)
            {
                
                UnitManager.Instance.SelectUnit(unit);
            }
        }
    }
}
