using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSpriteRandomizer : MonoBehaviour
{
    public Sprite[] sprites;

    private void Awake()
    {
        int ranSprite = Random.Range(0,sprites.Length);
        GetComponentInChildren<SpriteRenderer>().sprite = sprites[ranSprite];
    }
}
