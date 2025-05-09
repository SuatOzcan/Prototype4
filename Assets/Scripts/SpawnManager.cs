using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private float _spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(GenerateEnemy), 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
