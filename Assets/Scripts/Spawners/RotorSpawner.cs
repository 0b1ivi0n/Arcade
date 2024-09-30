using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class RotorSpawner : EnemySpawner
{

    private List<SplineContainer> splines;
    private void OnValidate()
    {
        splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
    }
    protected override void SpawnEnemy()
    {

        var enemy = _pool.Get();
        SplineContainer spline = splines[Random.Range(0, splines.Count)];
        enemy.GetComponent<SplineAnimate>().Restart(true);
        enemy.transform.position = (Vector3)spline.EvaluatePosition(0f);

        var healthSystem = enemy.GetComponent<HealthSystem>();
        healthSystem.OnDie += HandleEnemyDie;

        enemiesSpawned++;
    }

    protected override GameObject Preload()
    {
        EnemyType enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];
        SplineContainer spline = splines[Random.Range(0, splines.Count)];
        return enemyFactory.CreateEnemy(enemyType, spline);
    }
}
