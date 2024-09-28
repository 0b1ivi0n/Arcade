using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private Transform connection;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = other.transform.position;
        other.transform.position = new Vector3(connection.position.x ,position.y, position.z);
    }

}
