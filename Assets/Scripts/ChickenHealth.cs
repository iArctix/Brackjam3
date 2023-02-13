using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHealth : MonoBehaviour
{
    float health;
    float maxHealth = 2f;

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            //Dead
        }
    }
    public void GainHealth()
    {
        health++;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
