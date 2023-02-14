using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce;
    public float fall;
    public float lowJump;

    Rigidbody2D rb;
    float jumpCount;

    Animator chickenAnim;
    public GameObject egg;

    AudioSource chickenAudio;
    public AudioClip[] chickenFart;

    bool isDead;
    bool rotate;

    public GameObject barrier;
    public void Start()
    {
        chickenAnim = GetComponent<Animator>();
        chickenAudio= GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 2f;
    }

    public void FixedUpdate()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (rotate)
        {
            rb.rotation += 10f;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0 && !isDead)
        {
            Jump();
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fall - 1) * Time.deltaTime;
        }else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (lowJump - 1) * Time.deltaTime;
        }

        barrier.transform.position = new Vector3(gameObject.transform.position.x - 20, barrier.transform.position.y, barrier.transform.position.z);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount--;
        chickenAnim.SetBool("isJumping", true);

        if(jumpCount == 0)
        {
            GameObject newEgg = Instantiate(egg, transform.position, Quaternion.identity);
            Destroy(newEgg, 3);

            int randNoise = Random.Range(0, chickenFart.Length);
            chickenAudio.clip = chickenFart[randNoise];
            chickenAudio.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && !isDead)
        {
            jumpCount = 2;
            chickenAnim.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !isDead)
        {
            //Grab Time
            TimeSystem ts = GetComponent<TimeSystem>();
            ts.isDead = true;
            float timeSurvived = ts.time;

            //Disable Things
            isDead = true;
            GetComponent<ChickenObstacleSpawning>().enabled = false;
            StartCoroutine(DeathRotation());

            //Death Animation
            chickenAnim.SetBool("isJumping", true);
        }
    }

    IEnumerator DeathRotation()
    {
        rotate = true;
        yield return new WaitForSeconds(1f);
        rotate = false;
    }
}
