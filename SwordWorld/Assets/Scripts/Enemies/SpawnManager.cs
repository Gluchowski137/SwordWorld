using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] eniemiesPrefab;
    private int countEnemies;
    private int waveNumber = 3;

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
    private Vector3 SpawnManager1()
    {
        float spawnPosX = Random.Range(3, 5);
        float spawnPosZ = Random.Range(-30, -27);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    private Vector3 SpawnManager2()
    {
        float spawnPosX = Random.Range(3, 5);
        float spawnPosZ = Random.Range(27, 30);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    private Vector3 SpawnManager3()
    {
        float spawnPosX = Random.Range(30, 35);
        float spawnPosZ = Random.Range(-3, 2);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    private Vector3 SpawnManager4()
    {
        float spawnPosX = Random.Range(-22, -27);
        float spawnPosZ = Random.Range(-3, 2);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    private Vector3 GenerateRandomPosition()
    {
        Vector3 spawn = new Vector3(0, 0, 0);
        int spawnManagerIndex = Random.Range(0, 4);
        if(spawnManagerIndex == 0)
        {
           
            spawn = SpawnManager1();
        }
        else if (spawnManagerIndex == 1)
        {
            
            spawn = SpawnManager2();

        }
        else if (spawnManagerIndex == 2)
        {
            
            spawn = SpawnManager3();
        }
        else if (spawnManagerIndex == 3)
        {
           
            spawn = SpawnManager4();
        }

        return spawn;
    }

       
    
}
