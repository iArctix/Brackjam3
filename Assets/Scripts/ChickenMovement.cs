using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenMovement : MonoBehaviour
{
    public static float endtimechicken;

    public float speed;
    public float jumpForce;
    public float fall;
    public float lowJump;

    Rigidbody2D rb;
    float jumpCount;

    Animator chickenAnim;
    public GameObject egg;
    public GameObject deadSprite;

    public AudioSource music;
    AudioSource chickenAudio;
    public AudioClip[] chickenFart;
    public AudioClip chickenJump;
    public AudioClip chickenDeath;
    public AudioClip chickenSign;

    bool isDead;
    bool rotate;
    bool spawned;
    bool canSkip;

    public GameObject barrier;

    public GameObject jumpParticles;
    public GameObject doubleJumpParticles;

    public GameObject endText1;
    public GameObject endText2;
    public GameObject panel;
    public GameObject bird;
    public GameObject birdText;
    public GameObject[] birdTutorial;
    public GameObject fadeAudio;
    public GameObject enterPress;
    public void Start()
    {
        chickenAnim = GetComponent<Animator>();
        chickenAudio= GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 2f;
        speed = 0f;
    }

    public void FixedUpdate()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            speed = speed += 0.5f * Time.deltaTime;
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

        if (rb.velocity == Vector2.zero && !spawned && isDead)
        {
            StartCoroutine(DeadChicken());
            spawned = true;
        }
        if (canSkip && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(3);
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount--;
        chickenAnim.SetBool("isJumping", true);

        if(jumpCount == 0)
        {
            GameObject newEgg = Instantiate(egg, transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
            Destroy(newEgg, 3);

            int randNoise = Random.Range(0, chickenFart.Length);
            chickenAudio.clip = chickenFart[randNoise];
            chickenAudio.Play();

            GameObject djParticle = Instantiate(doubleJumpParticles, transform.position - new Vector3(0, 0.5f, 0), doubleJumpParticles.transform.rotation);
            Destroy(djParticle, 2);
            return;
        }

        chickenAudio.clip = chickenJump;
        chickenAudio.Play();

        GameObject jParticle = Instantiate(jumpParticles, transform.position - new Vector3(0, 0.5f, 0), jumpParticles.transform.rotation);
        Destroy(jParticle, 2);
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
            Dead();

            chickenAudio.clip = chickenDeath;
            chickenAudio.Play();
        }

        if(collision.gameObject.tag == "SignObstacle" && !isDead)
        {
            Dead();
            chickenAudio.clip = chickenSign;
            chickenAudio.Play();
        }
    }

    IEnumerator DeathRotation()
    {
        rotate = true;
        yield return new WaitForSeconds(1f);
        rotate = false;
    }

    public void Dead()
    {
        //Grab Time
        TimeSystem ts = GetComponent<TimeSystem>();
        ts.isDead = true;
        float timeSurvived = ts.time;
        endtimechicken = timeSurvived;
        //Disable Things
        isDead = true;
        GetComponent<ChickenObstacleSpawning>().enabled = false;
        StartCoroutine(DeathRotation());

        //Death Animation + Sound
        chickenAnim.SetBool("isJumping", true);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 0.6f, 0.6f, 1);

        music.GetComponent<AudioSource>().Pause();
    }

    IEnumerator DeadChicken()
    {
        yield return new WaitForSeconds(2f);
        GameObject deadChicken = Instantiate(deadSprite, transform.position, Quaternion.identity);
        deadChicken.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2f);
        yield return new WaitForSeconds(0.7f);
        deadChicken.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(2f);
        endText1.SetActive(true);
        yield return new WaitForSeconds(5);
        endText1.SetActive(false);
        yield return new WaitForSeconds(2);
        endText2.SetActive(true);
        yield return new WaitForSeconds(5);
        endText2.SetActive(false);
        yield return new WaitForSeconds(2);
        panel.SetActive(true);
        fadeAudio.SetActive(true);
        yield return new WaitForSeconds(5);
        bird.SetActive(true);
        yield return new WaitForSeconds(3);
        birdText.SetActive(true);
        yield return new WaitForSeconds(5);
        birdText.SetActive(false);
        foreach (var item in birdTutorial)
        {
            item.SetActive(true);
        }
        yield return new WaitForSeconds(5);
        enterPress.SetActive(true);
        canSkip = true;
    }
}
