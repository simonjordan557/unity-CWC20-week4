using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int waveCounter = 1;
    public int enemyCounter = 0;
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnX;
    private float spawnZ;
    private float spawnRange = 8.0f;
    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 0);
        Invoke("SpawnPowerUp", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter == 0)
        {
            SpawnNextWave();
        }
    }

    private void SpawnEnemy()
    {
        
        Instantiate(enemyPrefab, GenerateRandomVector3(), enemyPrefab.transform.rotation);
        enemyCounter++;
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateRandomVector3(), powerUpPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomVector3()
    {
        spawnX = Random.Range(-spawnRange, spawnRange);
        spawnZ = Random.Range(-spawnRange, spawnRange);
        spawnPos = new Vector3(spawnX, 0, spawnZ);
        return spawnPos;
    }

    private void SpawnNextWave()
    {
        SpawnPowerUp();
        waveCounter++;

        for (int i = 0; i < waveCounter; i++)
        {
            SpawnEnemy();
        }
    }
}
