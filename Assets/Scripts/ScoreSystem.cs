using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float score;
    public float[] scores;
    int currentScore;
    private void FixedUpdate()
    {
        score = score += (Time.deltaTime * 7);
        if (score > scores[currentScore])
        {
            GetComponent<ChickenMovement>().speed += 2;
            currentScore++;
        }
    }
}
