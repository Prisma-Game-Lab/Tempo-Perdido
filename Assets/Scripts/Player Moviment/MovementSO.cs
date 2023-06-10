using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementSO", menuName = "ScriptableObjects/Movement")]
public class MovementSO : ScriptableObject
{
    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public bool redirect = false;
}
