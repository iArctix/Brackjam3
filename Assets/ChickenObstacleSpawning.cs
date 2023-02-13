using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenObstacleSpawning : MonoBehaviour
{
    public GameObject obstacles;
    float timer;
    public void SpawnObject()
    {
        Vector2 spawnPos = new Vector2(gameObject.transform.position.x + 15f, 0);
        GameObject obstacle = Instantiate(obstacles, spawnPos, Quaternion.identity);
        Destroy(obstacle, 5);

        timer = Random.Range(1.5f, 5);
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