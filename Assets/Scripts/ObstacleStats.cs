using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStats : MonoBehaviour
{
    public ChickenObstacle[] obstacles;
    ChickenObstacle co;
    Rigidbody2D rb;
    Vector2 force;
    private void Awake()
    {
        //Decide which Obstacle to Spawn
        int rObstacle = Random.Range(0, obstacles.Length);
        co = obstacles[rObstacle];

        //Sprite
        int ranSprite = Random.Range(0, co.obstacleSprite.Length);
        GetComponent<SpriteRenderer>().sprite = co.obstacleSprite[ranSprite];

        //Rigidbody Force
        rb = GetComponent<Rigidbody2D>();
        float finalSpeed = Random.Range(co.minSpeed, co.maxSpeed);
        force = new Vector2(finalSpeed, rb.velocity.y);

        //Collider Size
        BoxCollider2D bx = GetComponent<BoxCollider2D>();
        bx.size = co.colliderSize;
    }

    private void FixedUpdate()
    {
        rb.velocity = -force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
