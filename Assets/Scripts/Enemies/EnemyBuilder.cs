using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyBuilder
{
    private GameObject enemyPrefab;
    private SplineContainer spline;
    private GameObject weaponPrefab;
    private int _health;
    private float speed;

    public EnemyBuilder SetEnemyPrefab(GameObject prefab)
    {
        enemyPrefab = prefab;
        return this;
    }

    public EnemyBuilder SetSpline(SplineContainer spline)
    {
        this.spline = spline;
        return this;
    }
    public EnemyBuilder SetWeaponPrefab(GameObject prefab)
    {
        weaponPrefab = prefab;
        return this;
    }

    public EnemyBuilder SetSpeed(float speed)
    {
        this.speed = speed;
        return this;
    }
    public EnemyBuilder SetHealth(int health)
    {
        _health = health;
        return this;
    }



    public GameObject Build()
    {
        GameObject instance = GameObject.Instantiate(enemyPrefab);

        if (spline != null)
        {
            SplineAnimate splineAnimate = instance.GetComponent<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;
            instance.transform.position = (Vector3)spline.EvaluatePosition(0f);
            splineAnimate.Restart(true);
        }
        else
        {
            instance.GetComponent<ShipMovement>().SetSpeed(speed);
        }

        var healthSystem = instance.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            instance.GetComponent<HealthSystem>().SetHealth(_health);
        }

        return instance;
    }




}
