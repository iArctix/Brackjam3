using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TimeSystem : MonoBehaviour
{
    public float time;

    public bool isDead;
   
    public TextMeshProUGUI timeText;
    private void FixedUpdate()
    {
        if (!isDead)
        {
            time = time += Time.deltaTime;
        }
        timeText.text = time.ToString("F1");
    }
}
