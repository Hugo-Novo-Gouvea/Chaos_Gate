using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    int currentHealth, maxHealth, fireDamage;
    float fireRatio;

    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth; 
        fireRatio = 1;
        fireDamage = 1;
    }

}
