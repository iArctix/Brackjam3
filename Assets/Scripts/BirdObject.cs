using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObject : MonoBehaviour
{
    public BirdObjectData[] bod;
    BirdObjectData activeBod;
    Rigidbody2D rb;
    BoxCollider2D bc;
    SpriteRenderer sr;
    AudioSource aus;

    private void Awake()
    {
        int randomObject = Random.Range(0, bod.Length);
        activeBod = bod[randomObject];
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        aus = GetComponent<AudioSource>();

        int ranSprite = Random.Range(0, activeBod.sprite.Length);
        sr.sprite = activeBod.sprite[ranSprite];

        sr.flipX = activeBod.flipX;

        bc.size = activeBod.boxColliderSize;
        aus.clip = activeBod.audio;
        aus.Play();
    }

    private void FixedUpdate()
    {
        float ranSpeed = Random.Range(activeBod.minSpeed, activeBod.maxSpeed);
        rb.velocity = new Vector2(ranSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
