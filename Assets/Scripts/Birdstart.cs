using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdstart : MonoBehaviour
{
    bool isstarted;
    public GameObject controls;
    public GameObject Player;
    // Start is called before the first frame update

    void Start()
    {
        controls.SetActive(true);
        Player.GetComponent<BirdController>().enabled = false;
        Player.GetComponent<BirdBuilding>().enabled = false;
        Player.GetComponent<TimeSystem>().enabled = false;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isstarted)
        {
            Player.GetComponent<BirdController>().enabled = true;
            Player.GetComponent<BirdBuilding>().enabled = true;
            Player.GetComponent<TimeSystem>().enabled = true;
            controls.SetActive(false);
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
