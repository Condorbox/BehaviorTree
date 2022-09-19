using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(menuName = "BehaviorTree/Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject projectilePrefab;
    public float horizontalForce = 5.0f;
    public float verticalForce = 5.0f;
}
