using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    int damage, initialDamage, damageUpgradesSum;
    float speed, initialSpeed, speedUpgradesSum;
    float gain, initialGain, gainUpgradesSum;

    public int max_HealthUpgrades, maxDamageUpgrades, maxSpeedUpgrades, maxGainUpgrades;

    public int[] maxHealthUpgrades, damageUpgrades;
    public float[] speedUpgrades, gainUpgrades;

    public float coin;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        coin = 0;
        initialMaxHealth = 1;
        initialDamage = 1;
        initialSpeed = 3;
        initialGain = 1;

        maxHealthUpgrades = new int[max_HealthUpgrades];
        damageUpgrades = new int[maxDamageUpgrades];
        speedUpgrades = new float[maxSpeedUpgrades];
        gainUpgrades = new float[maxGainUpgrades];

        for (int i = 0; i < max_HealthUpgrades; i++)
        {
            maxHealthUpgrades[i] = 0;
        }
        for (int i = 0; i < maxDamageUpgrades; i++)
        {
            damageUpgrades[i] = 0;
        }
        for (int i = 0; i < maxSpeedUpgrades; i++)
        {
            speedUpgrades[i] = 0;
        }
        for (int i = 0; i < maxGainUpgrades; i++)
        {
            gainUpgrades[i] = 0;
        }

        maxHealth = initialMaxHealth;
        damage = initialDamage;
        speed = initialSpeed;
        gain = initialGain;
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

    public void damageUp()
    {
        damageUpgradesSum = 0;

        for (int i = 0; i < maxDamageUpgrades; i++)
        {
            damageUpgradesSum += damageUpgrades[i];
        }

        damage = initialDamage + damageUpgradesSum;
    }

    public void speedUp()
    {
        speedUpgradesSum = 0;

        for (int i = 0; i < maxSpeedUpgrades; i++)
        {
            speedUpgradesSum += speedUpgrades[i];
        }

        speed = initialSpeed + speedUpgradesSum;
    }

    public void gainUp()
    {
        gainUpgradesSum = 0;

        for (int i = 0; i < maxGainUpgrades; i++)
        {
            gainUpgradesSum += gainUpgrades[i];
        }

        gain = initialGain + gainUpgradesSum;
    }

    public int getHealth()
    {
        return maxHealth;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void enemyDead()
    {
        coin += gain;
    }
}
