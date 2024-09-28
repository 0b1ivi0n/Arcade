using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "EnemyType", order = 0)]
public class EnemyType : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject weaponPrefab;
    public float speed;
    public int health;
}
