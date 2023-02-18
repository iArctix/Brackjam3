using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BirdObject")]
public class BirdObjectData : ScriptableObject
{
    public Sprite[] sprite;
    public float minSpeed;
    public float maxSpeed;
    public Vector2 boxColliderSize;
    public bool flipX;

    public AudioClip audio;
}
