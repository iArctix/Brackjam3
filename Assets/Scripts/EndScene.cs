using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{

    public TextMeshProUGUI Chickenfinaltime;
    public TextMeshProUGUI Birdfinaltime;
    public GameObject chicken;
    public GameObject bird;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject panel;



    void Start()
    {
        StartCoroutine(EndSceneTing());
    }
    void Update()
    {
        Birdfinaltime.text = "You survived " + BirdController.finalTime.ToString("F1") + " seconds as a chicken";
        Chickenfinaltime.text = "You survived " + ChickenMovement.endtimechicken.ToString("F1") + " seconds as a bird";
    }

    IEnumerator EndSceneTing()
    {
        Text1.SetActive(true);
        yield return new WaitForSeconds(6f);
        Text1.SetActive(false);
        Text2.SetActive(true);
        yield return new WaitForSeconds(7f);
        Text2.SetActive(false);
        Text3.SetActive(true);
        yield return new WaitForSeconds(7f);
        Text3.SetActive(false);
        Text4.SetActive(true);
        yield return new WaitForSeconds(5f);
        Text4.SetActive(false);
        chicken.SetActive(true);
        bird.SetActive(true);
        yield return new WaitForSeconds(6f);
        panel.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(0);
    }   
}
