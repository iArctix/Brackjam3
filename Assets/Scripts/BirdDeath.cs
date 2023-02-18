using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeath : MonoBehaviour
{
    public Rigidbody2D bird;
    public GameObject deadBird;
    bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
            bird.rotation += 1f;
    }



    public IEnumerator Deadbird()
    {
        bird.constraints = RigidbodyConstraints2D.FreezeAll;
        //Change to Red
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 0.6f, 0.6f, 1);

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
}
