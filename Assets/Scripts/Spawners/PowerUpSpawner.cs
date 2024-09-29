using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _powers;
    [SerializeField] private float _spawnInterval;

    private float _spawnTimer;
    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval)
        {
            SpawnPower();
            _spawnTimer = 0f;
        }
    }

    private void SpawnPower()
    {
        var power = Instantiate(_powers[Random.Range(0, _powers.Count)]);

        var positionY = transform.position.y;
        var positionZ = transform.position.z - 10;
        var positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        var newPosition = new Vector3(positionX, positionY, positionZ);
        power.transform.position = newPosition;
    }
}
