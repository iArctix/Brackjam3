using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TimeSystem : MonoBehaviour
{
    public float time;
    public float[] times;
    int currentTime;
    bool maxSpeed = false;

    public bool isDead;
    public bool chicken;
    bool speedIncrease;
   
    public TextMeshProUGUI timeText;

    private void Start()
    {
        if (chicken)
        {
            speedIncrease = true;
        }
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            time = time += Time.deltaTime;
            if (speedIncrease)
            {
                if (time > times[currentTime] && !maxSpeed)
                {
                    if (currentTime >= times.Length)
                    {
                        maxSpeed = true;
                        currentTime = 8;
                        return;
                    }
                    if (!maxSpeed)
                    {
                        if (chicken)
                        {
                            GetComponent<ChickenMovement>().speed++;
                            currentTime++;

                            ChickenObstacleSpawning cos = GetComponent<ChickenObstacleSpawning>();
                            cos.minSpawn -= 0.2f;
                            cos.maxSpawn -= 0.25f;
                        }
                    }
                }
            }
        }
        timeText.text = time.ToString("F1");
    }
}
