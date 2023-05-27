using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    GameObject damageShop, fireRatioShop, healthShop;
    damageShop nDamageUpgrades;
    fireRatioShop nFireRatioUpgrades;
    healthShop nHealthUpgrades;
    
    public int fireDamage, initialFireDamage, fireDamageUpgradesSum; 
    int currentHealth, maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    float fireRatio, initialFireRatio, fireRatioUpgradesSum;

    int maxDamageUpgrades, maxFireRatioUpgrades, max_HealthUpgrades;

    int damageIncrement, fireRatioIncrement, healthIncrement;

    public int[] fireDamageUpgrades, maxHealthUpgrades;
    public float[] fireRatioUpgrades;


    void Start()
    {
        damageShop = GameObject.Find("damageShop");
        nDamageUpgrades = damageShop.GetComponent<damageShop>();

        fireRatioShop = GameObject.Find("fireRatioShop");
        nFireRatioUpgrades = fireRatioShop.GetComponent<fireRatioShop>();

        healthShop = GameObject.Find("healthShop");
        nHealthUpgrades = healthShop.GetComponent<healthShop>();

        maxDamageUpgrades = nDamageUpgrades.maxUpgrades;
        maxFireRatioUpgrades = nFireRatioUpgrades.maxUpgrades;
        max_HealthUpgrades = nHealthUpgrades.maxUpgrades;

        damageIncrement = 0;
        fireRatioIncrement = 0;
        healthIncrement = 0;

        initialMaxHealth = 3;
        initialFireRatio = 1;
        initialFireDamage = 1;
        currentHealth = initialMaxHealth;

        fireDamageUpgrades = new int[maxDamageUpgrades];
        maxHealthUpgrades = new int[max_HealthUpgrades];
        fireRatioUpgrades = new float[maxFireRatioUpgrades];

        for (int i = 0; i < maxDamageUpgrades; i++)
        {
            fireDamageUpgrades[i] = 0;
        }

        for (int i = 0; i < maxFireRatioUpgrades; i++)
        {
            fireRatioUpgrades[i] = 0;
        }

        for (int i = 0; i < max_HealthUpgrades; i++)
        {
            maxHealthUpgrades[i] = 0;
        }

        maxHealth = initialMaxHealth;
        fireRatio = initialFireRatio;
        fireDamage = initialFireDamage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fireDamageUp();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            fireRatioUp();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            maxHealthUp();
        }
    }

    public void fireDamageUp()
    {
        fireDamageUpgradesSum = 0;

        fireDamageUpgrades[damageIncrement] = nDamageUpgrades.upgrades[damageIncrement];

        damageIncrement++;

        for (int i = 0; i < maxDamageUpgrades; i++)
        {
            fireDamageUpgradesSum += fireDamageUpgrades[i];
        }
        
        fireDamage = initialFireDamage + fireDamageUpgradesSum;
    }

    public void fireRatioUp()
    {
        fireRatioUpgradesSum = 0;

        for (int i = 0; i < maxFireRatioUpgrades; i++)
        {
            fireRatioUpgradesSum += fireRatioUpgrades[i];
        }

        fireRatio = initialFireRatio + fireRatioUpgradesSum;
    }

    public void maxHealthUp()
    {
        maxHealthUpgradesSum = 0;

        for (int i = 0; i < max_HealthUpgrades; i++)
        {
            maxHealthUpgradesSum += maxHealthUpgrades[i];
        }

        maxHealth = initialMaxHealth + maxHealthUpgradesSum;
    }

    public int getFireDamage()
    {
        return fireDamage;
    }

    public float getFireRatio()
    {
        return fireRatio;
    }
}
