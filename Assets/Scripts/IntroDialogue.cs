using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject panel;
    public GameObject chicken;
    public GameObject chickenText;
    public GameObject[] tutorial;

    private void Start()
    {
        StartCoroutine(Dialogue());
    }
    IEnumerator Dialogue()
    {
        text1.SetActive(true);
        yield return new WaitForSeconds(5f);
        text1.SetActive(false);
        yield return new WaitForSeconds(1f);
        text2.SetActive(true);
        yield return new WaitForSeconds(5f);
        text2.SetActive(false);
        yield return new WaitForSeconds(2f);
        panel.SetActive(true);
        yield return new WaitForSeconds(5f);
        chicken.SetActive(true);
        yield return new WaitForSeconds(2f);
        chickenText.SetActive(true);
        yield return new WaitForSeconds(5f);
        chickenText.SetActive(false);
        foreach(var item in tutorial)
        {
            item.SetActive(true);
        }

    }
}
