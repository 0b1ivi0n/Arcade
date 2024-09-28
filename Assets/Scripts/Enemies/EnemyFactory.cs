using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyFactory
{
    public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline)
    {
        EnemyBuilder builder = new EnemyBuilder()
            .SetEnemyPrefab(enemyType.enemyPrefab)
            .SetSpline(spline)
            .SetSpeed(enemyType.speed)
            .SetHealth(enemyType.health);

        return builder.Build();
    }

    public GameObject CreateEnemy(EnemyType enemyType)
    {
        EnemyBuilder builder = new EnemyBuilder()
            .SetEnemyPrefab(enemyType.enemyPrefab)
            .SetSpeed(enemyType.speed)
            .SetHealth(enemyType.health);

        return builder.Build();
    }
    // more
}
