using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float score;

    private void FixedUpdate()
    {
        score = score += (Time.deltaTime * 7);
    }
}
