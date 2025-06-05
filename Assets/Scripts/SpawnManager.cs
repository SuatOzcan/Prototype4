using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _powerupPrefab;
    private float _spawnRange = 9.0f;
    [SerializeField]
    private int _enemiesToSpawn = 3;
    private int _enemyCount;
    private int _powerUpCount = 1;

    private GameObject[] _enemies;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(_enemiesToSpawn);
        //InvokeRepeating(nameof(GenerateEnemy), 0.0f, 5.0f); 2.7000000476837158203125f
        var myRandomFloat = Random.Range(float.MaxValue, float.MaxValue);
        bool result = myRandomFloat == 2;
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = FindObjectsOfType<Enemy>().Length;

        if(_enemyCount == 0)
        {
            ++_enemiesToSpawn;
            ++_powerUpCount;
            GeneratePowerUp();
            SpawnEnemyWave(_enemiesToSpawn);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-_spawnRange, _spawnRange);
        float spawnZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }

    void GenerateEnemy()
    {
        Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
    } 
    void GeneratePowerUp()
    {
        Instantiate(_powerupPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GenerateEnemy();
        }
    }
}
