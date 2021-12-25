using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    internal int health { get; }
    internal int damage { get; }
    internal float moveSpeed { get; }
    internal float turnSpeed { get; }
    internal string color { get; }

    public EnemyModel(EnemySO enemySO)
    {
        health = enemySO.health;
        damage = enemySO.damage;
        moveSpeed = enemySO.moveSpeed;
        turnSpeed = enemySO.turnSpeed;
        color = enemySO.color;
    }
}
