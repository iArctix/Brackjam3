using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject chicken;
    public SpriteRenderer chickensprite;
   
    float rightspeed =5;
    

    void Start()
    {
        
        StartCoroutine(movingright());
    }
    void Update()
    {
       
    }
    public void Startgame()
    {
        StartCoroutine(game());
    }


    IEnumerator movingright()
    {
        chickensprite.flipX = false;
        transform.position += new Vector3(rightspeed * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(5f);
        StartCoroutine(movingleft());
    }
    IEnumerator movingleft()
    {
        chickensprite.flipX = true;
        transform.position += new Vector3(-rightspeed * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(5f);
        StartCoroutine(movingright());
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
