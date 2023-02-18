using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCam : MonoBehaviour
{
    public Transform target;

    public void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + 7, 0, -10);
    }
}
