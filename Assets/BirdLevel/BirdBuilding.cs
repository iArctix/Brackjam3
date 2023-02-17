using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBuilding : MonoBehaviour
{
    public GameObject[] buildings;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        float countdown = time -= Time.deltaTime;
        if(countdown <= 0)
        {
            SpawnBuilding();
            Randomtime();
        }
    }
    void SpawnBuilding()
    {
        float y = Random.Range(-3.5f, 4);
        int t = Random.Range(0, buildings.Length);
        Vector2 spawnPos = new Vector2(gameObject.transform.position.x + 20, y);
        GameObject newbuilding = Instantiate(buildings[t], spawnPos,Quaternion.identity);
        
    }

    void Randomtime()
    {
        time = Random.Range(1,5);
    }
}
