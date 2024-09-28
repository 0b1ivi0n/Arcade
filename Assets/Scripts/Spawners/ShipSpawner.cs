using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : EnemySpawner
{

    protected override void SpawnEnemy()
    {
        var enemy = _pool.Get();

        var positionY = transform.position.y;
        var positionZ = transform.position.z - 10;
        var positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        var newPosition = new Vector3(positionX, positionY, positionZ);
        enemy.transform.position = newPosition;

        enemiesSpawned++;
    }

       protected override GameObject Preload()
    {
        EnemyType enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];
        return enemyFactory.CreateEnemy(enemyType);
    }
}
