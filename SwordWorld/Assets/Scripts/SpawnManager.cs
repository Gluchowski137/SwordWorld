using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] eniemiesPrefab;
    private int countEnemies;
    private int waveNumber = 0;
    private float spawnRange = 18f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (countEnemies == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomindex = Random.Range(0, eniemiesPrefab.Length);
            Instantiate(eniemiesPrefab[randomindex], GenerateRandomPosition(), eniemiesPrefab[randomindex].transform.rotation);
        }
    }
    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
