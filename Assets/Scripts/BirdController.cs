using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator birdAnim;
    [Header("GameObjects")]
    public GameObject cam;
    public GameObject deadBird;
    [Header("Stats")]
    public float speed;
    public float jumpForce;
    public float fall;
    public float lowjump;
    bool dead;
    bool rotate;
    bool isAnimated;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        birdAnim = GetComponent<Animator>();
    }
    private void Update()
    {
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

        if (rotate)
            rb.rotation += 1f;
    }
    private void LateUpdate()
    {
        cam.transform.position = new Vector3(gameObject.transform.position.x + 6, cam.transform.position.y, -10);
    }
    void Movement()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    IEnumerator Death()
    {
        dead = true;

        //Change to Red
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 0.6f, 0.6f, 1);

        //Do some Rotation
        rotate = true;
        yield return new WaitForSeconds(1f);
        rotate = false;

        //Dead Bird
        yield return new WaitForSeconds(2f);
        GameObject deadBirdd = Instantiate(deadBird, transform.position, Quaternion.identity);
        deadBirdd.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2f);
        yield return new WaitForSeconds(0.7f);
        deadBirdd.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
}
