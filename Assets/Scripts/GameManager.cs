using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject Spawn, coinText;

    int maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    int damage, initialDamage, damageUpgradesSum;
    float speed, initialSpeed, speedUpgradesSum;
    float gain, initialGain, gainUpgradesSum;
    int numEnemyDead = 0, currentLevel = 0;

    int numLevels;

    public int[] levels, maxHealthUpgrades, damageUpgrades;
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

        numLevels = levels.Length;

        maxHealth = initialMaxHealth;
        damage = initialDamage;
        speed = initialSpeed;
        gain = initialGain;

        Spawn = GameObject.Find("Spawns");
        coinText = GameObject.Find("TextCoin");
    }


    public void maxHealthUp(int level)
    {
        maxHealthUpgradesSum = 0;

        for (int i = 0; i <= level; i++)
        {
            maxHealthUpgradesSum += maxHealthUpgrades[i];
        }

        maxHealth = initialMaxHealth + maxHealthUpgradesSum;
    }

    public void damageUp(int level)
    {
        damageUpgradesSum = 0;

        for (int i = 0; i <= level; i++)
        {
            damageUpgradesSum += damageUpgrades[i];
        }

        damage = initialDamage + damageUpgradesSum;
    }

    public void speedUp(int level)
    {
        speedUpgradesSum = 0;

        for (int i = 0; i <= level; i++)
        {
            speedUpgradesSum += speedUpgrades[i];
        }

        speed = initialSpeed + speedUpgradesSum;
    }

    public void gainUp(int level)
    {
        gainUpgradesSum = 0;

        for (int i = 0; i <= level; i++)
        {
            gainUpgradesSum += gainUpgrades[i];
        }

        gain = initialGain + gainUpgradesSum;
    }

    public int getHealth()
    {
        return maxHealth;
    }

    public int getDamage()
    {
        return damage;
    }

    public float getSpeed()
    {
        return speed;
    }

    public float getNumEnemyDead()
    {
        return numEnemyDead;
    }

    public void enemyDead()
    {
        coin += gain;
        numEnemyDead ++;
        attText();
    }

    public void attText()
    {
        coinText.GetComponent<Text>().text = coin.ToString();
    }

    public void resetEnemy()
    {
        numEnemyDead = 0;
    }

    public void newHorde()
    {
        maxHealthUp(currentLevel);
        damageUp(currentLevel);
        speedUp(currentLevel);
        gainUp(currentLevel);
        Spawn.GetComponent<SpawnEnemy>().attEnemyNum(levels[currentLevel]);
        currentLevel ++;

    }
}
