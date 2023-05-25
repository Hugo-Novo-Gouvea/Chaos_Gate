using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    int fireDamage, initialFireDamage, fireDamageUpgradesSum; 
    int currentHealth, maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    float fireRatio, initialFireRatio, fireRatioUpgradesSum;

    public int maxUpgrades;

    public int[] fireDamageUpgrades, maxHealthUpgrades;
    public float[] fireRatioUpgrades;


    void Start()
    {
        maxUpgrades = 5;
        initialMaxHealth = 3;
        initialFireRatio = 1;
        initialFireDamage = 1;
        currentHealth = initialMaxHealth;

        for (int i = 0; i < maxUpgrades; i++)
        {
            fireDamageUpgrades[i] = 0;
            fireRatioUpgrades[i] = 0;
            maxHealthUpgrades[i] = 0;
        }
    }

    public void fireDamageUp()
    {
        for (int i = 0; i < maxUpgrades; i++)
        {
            fireDamageUpgradesSum += fireDamageUpgrades[i];
        }
        
        fireDamage = initialFireDamage + fireDamageUpgradesSum;
    }

    public void fireRatioUp()
    {
        for (int i = 0; i < maxUpgrades; i++)
        {
            fireRatioUpgradesSum += fireRatioUpgrades[i];
        }

        fireRatio = initialFireRatio + fireRatioUpgradesSum;
    }

    public void maxHealthUp()
    {
        for (int i = 0; i < maxUpgrades; i++)
        {
            maxHealthUpgradesSum += maxHealthUpgrades[i];
        }

        maxHealth = initialMaxHealth + maxHealthUpgradesSum;
    }
}
