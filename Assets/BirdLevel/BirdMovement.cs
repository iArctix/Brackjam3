using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    
    //Horizontal Movement
    public float upForce = 400f;
    public float fall;
    public float lowjump; 

    //Vertical Movement 
    public float rightspeed = 15f;
    public float acceleration = 0.5f;

    private Rigidbody2D birdRigidbody;
    public GameObject Camera;
    public GameObject Player;
    public bool isalive;
    //Timer Vars
    public static string minutesfinal;
    public static string secondsfinal;
    private float startTime;
    public TMPro.TextMeshProUGUI timertext;


    private void Start()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
        isalive = true;
        startTime = Time.time;
    }
    private void Update()
    {
        Movement();
        Timer();
        CameraMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Dead());
        Debug.Log("Dead");
    }
    public void CameraMovement()
    {
        
    }

    void Movement()
    { 
        if(birdRigidbody.velocity.y < 0)
        {
            birdRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fall-1) * Time.deltaTime;
        }
        else if(birdRigidbody.velocity.y > 0  && !Input.GetMouseButton(0))
        {
            birdRigidbody.velocity += Vector2.up * Physics2D.gravity.y *(lowjump-1)*Time.deltaTime;
        }



        if (isalive)
        {
            //Vertical Movement
            if (Input.GetMouseButtonDown(0))
            {
                birdRigidbody.velocity = Vector2.zero;
                birdRigidbody.AddForce(new Vector2(0, upForce));

            }
            //Horizontal Movement
            transform.position += new Vector3(rightspeed * Time.deltaTime, 0, 0);
            rightspeed += acceleration * Time.deltaTime;
        }
        
    }
    public void Timer()
    {
        if(isalive)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("F3");
            //vars that store final time
            minutesfinal = minutes;
            secondsfinal = seconds;
        }
        timertext.text = "Time: " + minutesfinal + ":" + secondsfinal;
    }
    IEnumerator Dead()
    {
        isalive = false;
        yield return new WaitForSeconds(0.2f);
        Camera.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
        //code for death idk

    }

}