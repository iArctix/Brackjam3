using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    
    public GameObject chicken;
    public SpriteRenderer chickensprite;
    public GameObject playimage;
    public GameObject quitimage;
    private Rigidbody2D chichenrb;
    public bool rotate;
    public GameObject fadeout;
    
    public GameObject car;

    public TMPro.TextMeshProUGUI Playtext;
    public TMPro.TextMeshProUGUI Quittext;

    float rightspeed =5;
    float leftspeed = 0;

    bool dieded;
    public void Start()
    {
        rightspeed = 0;
        leftspeed = 0;
        chichenrb = GetComponent<Rigidbody2D>();



    }
    public void Update()
    {
        if (!dieded)
        {
            transform.position += new Vector3(rightspeed * Time.deltaTime, 0, 0);
        }
        car.transform.position += new Vector3 ( -(leftspeed * Time.deltaTime), 0, 0);

        if (rotate)
            chichenrb.rotation += 1f;
    }
    public void Startgame()
    {
        StartCoroutine(game());
    }

    IEnumerator game()
    {
        leftspeed = 9;
        rightspeed = 4;
        yield return new WaitForSeconds(1.25f);
        //play a deathsound
        rightspeed = 0;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 0.6f, 0.6f, 1);
        yield return new WaitForSeconds(1f);
        fadeout.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);


       // SceneManager.LoadScene("DialogueScene");
    }

   public void Quit()
    {
        Application.Quit();
    }

    public void startenter()
    {
        
        playimage.SetActive(true);
       
        Playtext.color = Color.white;
        Playtext.fontSize = 70;
    }

    public void startexit()
    {
        playimage.SetActive(false);
       
        Playtext.color = Color.black;
        Playtext.fontSize = 60;
    }
    public void quitenter()
    {

        quitimage.SetActive(true);
        //select sound
        Quittext.color = Color.white;
        Quittext.fontSize = 70;
    }

    public void quitexit()
    {
        quitimage.SetActive(false);
        
        Quittext.color = Color.black;
        Quittext.fontSize = 60;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            chichenrb.velocity = new Vector2(-5, 15);
            //rotate = true;
        }
    }
}
