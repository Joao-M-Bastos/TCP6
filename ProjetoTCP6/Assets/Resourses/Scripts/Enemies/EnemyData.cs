using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat System /Enemies")]

public class EnemyData : ScriptableObject
{
    public int ID;
    public string displayName;
    [TextArea(4, 4)] public string description;
    public GameObject enemyPrefab;
    public int life;
    public int damage;
    public float speed;
    public float viewDistance;
    public float attackDistance;
    public float baseAttackCooldown;
}
