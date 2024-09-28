using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    protected float _speed = 2f;
    protected Rigidbody2D _rb;
 

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate()
    {
        _rb.velocity = new Vector2(0, -_speed);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
