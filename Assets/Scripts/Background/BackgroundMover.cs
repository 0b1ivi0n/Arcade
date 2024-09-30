using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float speed = 50f; 

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
 
        rectTransform.anchoredPosition += new Vector2(0, speed * Time.deltaTime);

        if (rectTransform.anchoredPosition.y >= 2400)
        {
            rectTransform.anchoredPosition = new Vector2(0, 0); 
        }
    }
}