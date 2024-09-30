using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.U2D;

public abstract class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected List<EnemyType> enemyTypes;
    [SerializeField] protected int maxEnemies = 10;
    [SerializeField] protected float spawnInterval = 2f;

    protected EnemyFactory enemyFactory;

    protected float spawnTimer;
    protected int enemiesSpawned;
    
    protected Pool _pool;

    protected void Start()
    {
        enemyFactory = new EnemyFactory();
        _pool = new Pool(Preload, maxEnemies);
    }

    protected void Update()
    {
        spawnTimer += Time.deltaTime;

        if (enemiesSpawned < maxEnemies && spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

    }
    protected abstract void SpawnEnemy();
    protected abstract GameObject Preload();
    protected void HandleEnemyDie(GameObject enemy)
    {
        _pool.Return(enemy);
        enemiesSpawned--;
        var healthSystem = enemy.GetComponent<HealthSystem>();
        healthSystem.OnDie -= HandleEnemyDie;
        healthSystem.ResetHealth();
    }

}
