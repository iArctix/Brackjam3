using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TimeSystem : MonoBehaviour
{
    public float time;
    public float[] times;
    int currentTime;
    bool maxSpeed = false;

    public bool isDead;

    public TextMeshProUGUI timeText;
    private void FixedUpdate()
    {
        if (!isDead)
        {
            time = time += Time.deltaTime;
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
                    GetComponent<ChickenMovement>().speed++;
                    currentTime++;
                }
            }
        }

        timeText.text = time.ToString("F1");
    }
}
