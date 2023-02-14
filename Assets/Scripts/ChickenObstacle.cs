using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chicken Obstacle")]
public class ChickenObstacle : ScriptableObject
{
    [Header("Sprite")]
    public Sprite[] obstacleSprite;

    [Header("Stats")]
    public float minSpeed;
    public float maxSpeed;
    public Vector2 colliderSize;
    public bool horn;

    [Header("Sounds")]
    public AudioClip[] horns;
    public AudioClip specialHorn;
    public AudioClip[] engineNoise;
}
