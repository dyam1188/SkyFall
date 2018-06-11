using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnBoundary;

    [SerializeField]
    private GameObject[] Enemies;
    float spawnTime = 2.0f;

    int amountOfEnemiesToSpawn = 1;
    int currAmountOfEnemies = 0;
    int maxAmountOfEnemies = 4;
    int enemiesSpawnedSoFar = 0;
    int totalEnemiesToSpawn = 10;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2.0f, 3.0f);
    }

    void Update()
    {
    }

    void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnBoundary.x, spawnBoundary.x), spawnBoundary.y, spawnBoundary.z);
        int enemyIndex = Random.Range(0, Enemies.Length);

        Instantiate(Enemies[enemyIndex], spawnPosition, Enemies[enemyIndex].transform.rotation);
    }

    /*
    //In the case we need to limit the amount of enemies on screen/count the amount that have spawned
    void SpawnEnemies()
    {
        if (currAmountOfEnemies < maxAmountOfEnemies && enemiesSpawnedSoFar != totalEnemiesToSpawn)
        {
            for (int i = 0; i < amountOfEnemiesToSpawn; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnBoundary.x, spawnBoundary.x), spawnBoundary.y, spawnBoundary.z);
                Quaternion newQuaternion = new Quaternion();
                newQuaternion.Set(0, 0, 180, 1);
                int enemyIndex = Random.Range(0, Enemies.Length);

                Instantiate(Enemies[enemyIndex], spawnPosition, newQuaternion);
                currAmountOfEnemies++;
                enemiesSpawnedSoFar++;
            }
        }
    }
    */
}
