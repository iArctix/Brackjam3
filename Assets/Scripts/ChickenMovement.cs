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

    public Animator chickenAnim;

    public GameObject egg;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 2f;
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 2;
            chickenAnim.SetBool("isJumping", false);
        }
    }
}
