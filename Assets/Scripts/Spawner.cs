using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _startTimeToSpawn = 1;
    private float _spawnTimeInterval = 2;

    public GameObject _asteroid;

    void Start()
    {
        InvokeRepeating("addAsteroid", _startTimeToSpawn, _spawnTimeInterval);
    }

    private void addAsteroid()
    {
        Renderer spriteRenderer = GetComponent<Renderer>();

        var minXValue = transform.position.x - (spriteRenderer.bounds.size.x / 2);
        var maxXValue = transform.position.x + (spriteRenderer.bounds.size.x / 2);

        var spawnPosition = new Vector2(Random.Range(minXValue, maxXValue), 4.5f);

        Instantiate(_asteroid, spawnPosition, Quaternion.identity);
    }
}
