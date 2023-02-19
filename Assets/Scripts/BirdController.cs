using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BirdController : MonoBehaviour
{
    public static float finalTime;

    Rigidbody2D rb;
    Animator birdAnim;
    GameObject music;
    AudioSource birdAudio;

    [Header("GameObjects")]
    public GameObject cam;
    public GameObject deadBird;
    public GameObject barrier;

    [Header("Stats")]
    public float speed;
    public float jumpForce;
    public float fall;
    public float lowjump;
    bool dead;
    bool rotate;
    bool isAnimated;
    bool spawned;

    [Header("AudioClips")]
    public AudioClip jump;
    public AudioClip death;


    public GameObject controls;

    public GameObject text1;
    public GameObject text2;
    public GameObject panel;


    private void Start()
    {
        controls.SetActive(true);

        music = GameObject.Find("Music");
        if (music != null)
            music.GetComponent<AudioSource>().Play();

        rb = GetComponent<Rigidbody2D>();
        birdAnim = GetComponent<Animator>();
        birdAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) )
        {
            controls.SetActive(false);
        }

        if (!dead)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            Movement();
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fall - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjump - 1) * Time.deltaTime;
        }

        barrier.transform.position = new Vector3(gameObject.transform.position.x - 15, 0, 0);

        if (rb.velocity == Vector2.zero && !spawned && dead)
        {
            StartCoroutine(DeadBird());
            spawned = true;
        }
    }
    private void LateUpdate()
    {
        
        cam.transform.position = new Vector3(gameObject.transform.position.x + 6, cam.transform.position.y, -10);
    }
    void Movement()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        speed = speed += 0.5f * Time.deltaTime;
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        birdAudio.clip = jump;
        birdAudio.Play();

        StartCoroutine(BirdFlyAnimation());
    }

    IEnumerator Death()
    {
        if(music != null)
        {
            music.GetComponent<AudioSource>().Stop();
        }
        dead = true;
        GetComponent<BirdBuilding>().enabled = false;

        TimeSystem ts = GetComponent<TimeSystem>();
        finalTime = ts.time;
        ts.isDead = true;
        //Audio
        birdAudio.clip = death;
        birdAudio.Play();

        //Change to Red
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 0.6f, 0.6f, 1);
        yield return new WaitForSeconds(0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle" && !dead)
        {
            StartCoroutine(Death());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !dead)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator BirdFlyAnimation()
    {
        birdAnim.SetBool("isFly", true);
        isAnimated = true;
        yield return new WaitForSeconds(0.5f);
        birdAnim.SetBool("isFly", false);
        isAnimated = false;
    }

    IEnumerator DeadBird()
    {
        yield return new WaitForSeconds(2f);
        GameObject deadBirdd = Instantiate(deadBird, transform.position, Quaternion.identity);
        deadBirdd.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2f);
        yield return new WaitForSeconds(0.7f);
        deadBirdd.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(2);
        text1.SetActive(true);
        yield return new WaitForSeconds(4f);
        text1.SetActive(false);
        yield return new WaitForSeconds(2f);
        text2.SetActive(true);
        yield return new WaitForSeconds(5f);
        text2.SetActive(false);
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(4);
    }
}
