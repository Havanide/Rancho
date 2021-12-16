using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public float spawnPosZ = 20f;

    void Start()
    {
        InvokeRepeating("SpawnObstaclesOne", Random.Range(2f, 5f), Random.Range(2f, 8f));
        InvokeRepeating("SpawnObstaclesTwo", Random.Range(2f, 5f), Random.Range(2f, 8f));
        InvokeRepeating("SpawnObstaclesThree", Random.Range(2f, 5f), Random.Range(2f, 8f));
    }

    void SpawnObstaclesOne()
    {
        int obsIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = new Vector3(1, 0, spawnPosZ);

        Instantiate(
            obstacles[obsIndex],
            spawnPos,
            obstacles[obsIndex].transform.rotation);
    }

    void SpawnObstaclesTwo()
    {
        int obsIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = new Vector3(PlayerController.lineDistance + 1, 0, spawnPosZ);

        Instantiate(
            obstacles[obsIndex],
            spawnPos,
            obstacles[obsIndex].transform.rotation);
    }

    void SpawnObstaclesThree()
    {
        int obsIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = new Vector3(-PlayerController.lineDistance + 1, 0, spawnPosZ);

        Instantiate(
            obstacles[obsIndex],
            spawnPos,
            obstacles[obsIndex].transform.rotation);
    }
}
