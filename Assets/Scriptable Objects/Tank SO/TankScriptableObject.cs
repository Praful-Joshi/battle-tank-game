using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank Scriptable Objects", menuName = "Scriptable Objects/New Tank")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes tankType;
    public int health;
    public int damage;
    public float moveSpeed;
    public float turnSpeed;
    public string color;
    /*public GameObject tankPrefab;*/
}
