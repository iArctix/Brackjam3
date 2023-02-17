using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBuilding : MonoBehaviour
{
    public GameObject[] buildings;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBuilding()
    {
        int t = Random.Range(0, buildings.Length);
        Vector2 spawnPos = new Vector2(gameObject.transform.position.x + 20, 0.3f);
        GameObject newbuilding = Instantiate(buildings[t], spawnPos,Quaternion.identity);
    }
}
