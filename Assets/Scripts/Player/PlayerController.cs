using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedHorizontal;
    [SerializeField] private float speedVertical;
    [SerializeField] private float tiltSensitivity;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector2(rb.velocity.x, speedVertical);
                Debug.Log("зажат экран");
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speedVertical * 1.5f);
                Debug.Log("Одиночное касание завершено");
            }
        }

        float moveX = Input.acceleration.x * tiltSensitivity;
        //float moveY = Input.acceleration.y * tiltSensitivity;
        rb.velocity = new Vector2(speedHorizontal * Time.deltaTime * moveX, rb.velocity.y);
        //rb.velocity = new Vector2(speed * Time.deltaTime * moveX, speed * Time.deltaTime * moveY);
        //rb.AddForce(new Vector2(moveX * speed, 0), ForceMode2D.Force);
    }
}