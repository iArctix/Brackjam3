using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChickenObstacleSpawning : MonoBehaviour
{
    public GameObject obstacles;
    public GameObject[] SignObstacle;
    float timer;

    public float minSpawn;
    public float maxSpawn;

    private void Start()
    {
        minSpawn = 1.5f;
        maxSpawn = 5f;
    }
    public void SpawnObject()
    {
        //Spawn a Car
        Vector2 spawnPos = new Vector2(gameObject.transform.position.x + 20, 0.3f);
        GameObject obstacle = Instantiate(obstacles, spawnPos, Quaternion.identity);

        //Chance to Spawn a Sign
        int ranSign = Random.Range(0, 4);
        if(ranSign == 3)
        {
            Vector3 signSpawnPos = new Vector3(gameObject.transform.position.x + 20, 0.3f, 1f);
            int randomSign = Random.Range(0, SignObstacle.Length);
            GameObject signObstacles = Instantiate(SignObstacle[randomSign], signSpawnPos, Quaternion.identity);
        }

        timer = Random.Range(minSpawn, maxSpawn);
    }

    private void Update()
    {
        float countDown = timer -= Time.deltaTime;
        if(countDown <= 0)
        {
            SpawnObject();
        }
    }
}
