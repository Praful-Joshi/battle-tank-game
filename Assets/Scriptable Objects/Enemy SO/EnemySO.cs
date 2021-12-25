using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Tank Scriptable Object", menuName = "Scriptable Objects/New Enemy Tank")]
public class EnemySO : ScriptableObject
{
    public int health;
    public int damage;
    public float moveSpeed;
    public float turnSpeed;
    public string color;
}
