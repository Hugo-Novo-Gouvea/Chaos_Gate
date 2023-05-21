using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEnemy : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public float speed;


    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        speed = 4;
    }
}
