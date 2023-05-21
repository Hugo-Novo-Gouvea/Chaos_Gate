using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEnemy : MonoBehaviour
{
    int currentHealth, maxHealth;
    float speed;


    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        speed = 4;
    }
}
