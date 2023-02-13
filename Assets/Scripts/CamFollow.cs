using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    public void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + 7, 4, -10);
    }
}
