using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reincarnation : MonoBehaviour
{
    public GameObject[] players;
    int currentPlayer;
    public CamFollow cam;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Reincarnate());
        }
    }

    IEnumerator Reincarnate()
    {
        //Create Death Effect

        yield return new WaitForSeconds(2f);
        //Switch to Next Player
        players[currentPlayer].SetActive(false);
        currentPlayer++;
        if (currentPlayer >= players.Length)
        {
            currentPlayer = 0;
        }
        players[currentPlayer].SetActive(true);

        //Change Camera Target
        cam.target = players[currentPlayer].transform;
    }
}
