using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    //Movement Vars
    public float upForce = 200f;
    public float rightspeed = 2f;
    private Rigidbody2D birdRigidbody;
    public GameObject Camera;
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Dead());
        Debug.Log("Dead");
    }
    void Movement()
    { 
        if (isalive)
        {
            //horizontal movement
            if (Input.GetMouseButtonDown(0))
            {
                birdRigidbody.velocity = Vector2.zero;
                birdRigidbody.AddForce(new Vector2(0, upForce));

            }
            //vertical movement
            transform.position += new Vector3(rightspeed * Time.deltaTime, 0, 0);
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