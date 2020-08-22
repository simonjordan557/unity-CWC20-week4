using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRate = 3.0f;
    private float spawnX;
    private float spawnZ;
    private float spawnRange = 8.0f;
    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        spawnX = Random.Range(-spawnRange, spawnRange);
        spawnZ = Random.Range(-spawnRange, spawnRange);
        spawnPos = new Vector3(spawnX, 0, spawnZ);
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }
}
