using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Startgame()
    {
        StartCoroutine(game());
    }

    IEnumerator game()
    {
        //screen fades or some shit
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("DialogueScene");
    }

   public void Quit()
    {
        Application.Quit();
    }
}
