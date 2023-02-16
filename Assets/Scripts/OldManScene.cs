using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldManScene : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject whitePanel;
    public GameObject chicken;
    public GameObject chickenText;
    public GameObject[] tutorial;
    public GameObject enterPress;

    bool canSkip;

    public GameObject fadetoWhiteAudio;
    private void Start()
    {
        StartCoroutine(OldManIntroScene());
    }

    IEnumerator OldManIntroScene()
    {
        yield return new WaitForSeconds(3);
        text1.SetActive(true);
        yield return new WaitForSeconds(5);
        text1.SetActive(false);
        yield return new WaitForSeconds(3);
        text2.SetActive(true);
        yield return new WaitForSeconds(5);
        text2.SetActive(false);
        yield return new WaitForSeconds(3);
        whitePanel.SetActive(true);
        fadetoWhiteAudio.SetActive(true);
        yield return new WaitForSeconds(5f);
        chicken.SetActive(true);
        yield return new WaitForSeconds(3);
        chickenText.SetActive(true);
        yield return new WaitForSeconds(5);
        chickenText.SetActive(false);
        foreach (var item in tutorial)
        {
            item.SetActive(true);
        }
        yield return new WaitForSeconds(5);
        enterPress.SetActive(true);
        canSkip = true;
    }

    private void Update()
    {
        if (canSkip && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(2);
        }
    }
}
