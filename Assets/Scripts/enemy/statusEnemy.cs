using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEnemy : MonoBehaviour
{
    public int currentHealth, maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    float speed, initialSpeed, speedUpgradesSum;

    public int maxUpgrades;

    public int[] maxHealthUpgrades;
    public float[] speedUpgrades;



    void Start()
    {
        initialMaxHealth = 3;
        initialSpeed = 4;
        currentHealth = initialMaxHealth;

        maxHealthUpgrades = new int[maxUpgrades];
        speedUpgrades = new float[maxUpgrades];

        for (int i = 0; i < maxUpgrades; i++)
        {
            maxHealthUpgrades[i] = 0;
            speedUpgrades[i] = 0;
        }

    }

    public void maxHealthUp()
    {
        for (int i = 0; i < maxUpgrades; i++)
        {
            maxHealthUpgradesSum += maxHealthUpgrades[i];
        }

        maxHealth = initialMaxHealth + maxHealthUpgradesSum;
    }

    public void speedUp()
    {
        for (int i = 0; i < maxUpgrades; i++)
        {
            speedUpgradesSum += speedUpgrades[i];
        }

        speed = initialSpeed + speedUpgradesSum;
    }
}
