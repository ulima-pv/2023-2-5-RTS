using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Unit")]
public class UnitTypeSO : ScriptableObject
{
    public string unitName;
    public float speed;
    public float hp;
}
