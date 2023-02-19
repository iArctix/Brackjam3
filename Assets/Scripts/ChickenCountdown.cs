using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCountdown : MonoBehaviour
{
    public GameObject chicken;
    public GameObject text;

    private void Start()
    {
        StartCoroutine(start());
        chicken.GetComponent<TimeSystem>().enabled = false;
        chicken.GetComponent<ChickenObstacleSpawning>().enabled = false;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            chicken.GetComponent<ChickenMovement>().enabled = true;
            chicken.GetComponent<TimeSystem>().enabled = true;
            chicken.GetComponent<ChickenObstacleSpawning>().enabled = true;
            chicken.GetComponent<ChickenMovement>().speed = 5;
            chicken.GetComponent<ChickenMovement>().Jump();
            text.SetActive(false);
        }
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(0.1f);
        chicken.GetComponent<ChickenMovement>().enabled = false;
    }
}
