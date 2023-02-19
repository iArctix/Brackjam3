using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBuilding : MonoBehaviour
{
    public GameObject objects;
    float time;

    void Update()
    {
        float countdown = time -= Time.deltaTime;
        if(countdown <= 0)
        {
            SpawnBuilding();
            StartCoroutine(DoubleSpawn());
            Randomtime();
        }
    }
    void SpawnBuilding()
    {
        float y = Random.Range(-3.5f, 4);
        Vector2 spawnPos = new Vector2(gameObject.transform.position.x + 20, y);
        GameObject newbuilding = Instantiate(objects, spawnPos,Quaternion.identity);  
    }

    void Randomtime()
    {
        time = Random.Range(1,5);
    }

    IEnumerator DoubleSpawn()
    {
        float t = Random.Range(0.5f, 2);
        yield return new WaitForSeconds(t);
        SpawnBuilding();
    }
}
