using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Spawn : MonoBehaviour
{
    public int spawnPosX = 10;
    public GameObject life;
    private float spawnInterval = 5f;
    private float startDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // calling function in loop after every few seconds
        InvokeRepeating("SpawnLife", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // spawning life within fixed boundaries 
    void SpawnLife()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, 0);
        Instantiate(life, spawnPos, Quaternion.identity);
    }
}
