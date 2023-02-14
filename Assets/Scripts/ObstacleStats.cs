using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStats : MonoBehaviour
{
    public ChickenObstacle[] genericObstacle;
    public ChickenObstacle[] specialObstacles;
    ChickenObstacle co;
    Rigidbody2D rb;
    Vector2 force;

    public AudioSource hornAudio;
    public AudioSource engineAudio;
    private void Awake()
    {
        //Decide which Obstacle to Spawn
        int specialOb = Random.Range(0, 11);
        if(specialOb < 9) //Generic Obstacle
        {
            int rObstacle = Random.Range(0, genericObstacle.Length);
            co = genericObstacle[rObstacle];
        }else //Special {Harder} Obstacle
        {
            int rObstacle = Random.Range(0, specialObstacles.Length);
            co = specialObstacles[rObstacle];
        }

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

        //Sound
        if(co.horn)
        {
            //Horn
            int spec = Random.Range(0, 11);
            if (spec < 9)
            {
                int ranNoise = Random.Range(0, co.horns.Length);
                hornAudio.clip = co.horns[ranNoise];
                hornAudio.Play();
            }
            else
            {
                hornAudio.clip = co.specialHorn;
                hornAudio.Play();
            }
        }

        //Engine Noise
        int ranEngine = Random.Range(0, co.engineNoise.Length);
        engineAudio.clip = co.engineNoise[ranEngine];
        engineAudio.Play();
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
