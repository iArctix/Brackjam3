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

    //Animation
    Animator birdAnim;
    bool isAnimated;
    bool rotate;
    public GameObject deadBird;

    private void Start()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
        birdAnim = GetComponent<Animator>();
        isalive = true;
        startTime = Time.time;
    }
    private void Update()
    {
        Movement();
        Timer();

        if(rotate)
            birdRigidbody.rotation += 1f;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Dead());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine(Dead());
        }
    }

    void Movement()
    { 
        if(birdRigidbody.velocity.y < 0)
        {
            birdRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fall-1) * Time.deltaTime;
        }
        else if(birdRigidbody.velocity.y > 0  && !Input.GetButtonDown("Jump"))
        {
            birdRigidbody.velocity += Vector2.up * Physics2D.gravity.y *(lowjump-1)*Time.deltaTime;
        }



        if (isalive)
        {
            //Vertical Movement
            if (Input.GetButtonDown("Jump"))
            {
                birdRigidbody.velocity = Vector2.zero;
                birdRigidbody.AddForce(new Vector2(0, upForce));

                if (!isAnimated)
                {
                    StartCoroutine(BirdFlyAnimation());
                }
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
            //string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("F1");
            //vars that store final time
            //minutesfinal = minutes;
            secondsfinal = seconds;
        }
        timertext.text = "Time: " + secondsfinal;
    }
    IEnumerator Dead()
    {
        //Change to Red
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 0.6f, 0.6f, 1);
        isalive = false;
        //Do some Rotation
        rotate = true;
        yield return new WaitForSeconds(1f);
        rotate = false;

        yield return new WaitForSeconds(2f);
        GameObject deadBirdd = Instantiate(deadBird, transform.position, Quaternion.identity);
        deadBirdd.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2f);
        yield return new WaitForSeconds(0.7f);
        deadBirdd.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    IEnumerator BirdFlyAnimation()
    {
        birdAnim.SetBool("isFly", true);
        isAnimated = true;
        yield return new WaitForSeconds(0.5f);
        birdAnim.SetBool("isFly", false);
        isAnimated = false;
    }
}