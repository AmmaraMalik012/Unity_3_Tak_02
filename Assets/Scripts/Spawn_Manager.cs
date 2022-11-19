using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public int spawnPosX = 17;
    public GameObject[] spawnPrefabs;
    private float spawnInterval = 3f;
    private float startDelay = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBalls", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomBalls()
    {
        int ballIndex = Random.Range(0, spawnPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, 0);
        Instantiate(spawnPrefabs[ballIndex], spawnPos, Quaternion.identity);
    }
}
