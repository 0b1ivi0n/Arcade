using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShipMovement : ShipMovement
{
    [SerializeField] private float _maxSpeed;

    protected override void Start()
    {
        base.Start();
        _speed = Random.Range(_speed, _maxSpeed);
    }


}
