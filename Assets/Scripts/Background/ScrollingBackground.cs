using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speedScrolling;
    Vector2 startPosition;
    float length;

    void Start()
    {
        startPosition = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        var offset = Mathf.Repeat(Time.time * speedScrolling, length);
        transform.position = startPosition + Vector2.down * offset;
    }

}
