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

    //protected abstract void SpawnEnemy()
    //{
    //    //EnemyType enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];
    //    //SplineContainer spline = splines[Random.Range(0, splines.Count)];

    //    // do pool
    //    //enemyFactory.CreateEnemy(enemyType, spline);
    //    var enemy = _pool.Get();
    //    SplineContainer spline = splines[Random.Range(0, splines.Count)];
    //    enemy.GetComponent<SplineAnimate>().Restart(true);
    //    enemy.transform.position = (Vector3)spline.EvaluatePosition(0f);
    //    enemiesSpawned++;
    //    //StartCoroutine(Test(enemy));
    //}

    ////IEnumerator Test(GameObject enemy)
    ////{
    ////    yield return new WaitForSeconds(5f);
    ////    _pool.Return(enemy);
    ////    enemiesSpawned--;
    ////}

    //protected abstract GameObject Preload()
    //{
    //    EnemyType enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];
    //    SplineContainer spline = splines[Random.Range(0, splines.Count)];
    //    return enemyFactory.CreateEnemy(enemyType, spline);
    //}
}
