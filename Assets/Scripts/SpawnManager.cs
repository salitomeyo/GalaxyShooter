using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] [Tooltip("Enemy prefab")]
    private GameObject _enemy;

    [SerializeField] [Tooltip("Powerups prefab")]
    private GameObject[] _powerups;

    [SerializeField] [Tooltip("Enemy spawn rate")]
    private float _enemySpawnRate = 5f;

    [SerializeField] [Tooltip("Powerups spawn rate")]
    private float _powerupSpawnRate = 12f;

    private bool _booleanAux = true;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerup());

    }

    IEnumerator SpawnEnemy()
    {
        while(_booleanAux)
        {
            yield return new WaitForSeconds(_enemySpawnRate);
            float spawnX = Random.Range(-8.34f, 8.34f);
            Instantiate(_enemy, new Vector3 (spawnX, 5.39f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerup()
    {
        while(_booleanAux)
        {
            int powerupType = Random.Range(0, 3);
            yield return new WaitForSeconds(_powerupSpawnRate);
            float spawnX = Random.Range(-8.34f, 8.34f);
            Instantiate(_powerups[powerupType], new Vector3 (spawnX, 5.39f, 0), Quaternion.identity);
        }
    }
}
