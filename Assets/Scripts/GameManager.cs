using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject Spawn, coinText, waveText;

    private bool inCity = true;

    int maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    int damage, initialDamage, damageUpgradesSum;
    float speed, initialSpeed, speedUpgradesSum;
    float gain, initialGain, gainUpgradesSum;
    int numEnemyDead = 0, currentLevel = 0;

    public int numLevels;

    public int[] levels, maxHealthUpgrades, damageUpgrades;
    public float[] speedUpgrades, gainUpgrades;

    public float coin;
    public float speedSpawn;
    
    
    void Start()
    {
        coin = 0;
        initialMaxHealth = 1;
        initialDamage = 1;
        initialSpeed = 3;
        initialGain = 1;
        speedSpawn = 1;

        numLevels = levels.Length;

        maxHealth = initialMaxHealth;
        damage = initialDamage;
        speed = initialSpeed;
        gain = initialGain;

        maxHealthUpgrades = new int[numLevels];
        damageUpgrades = new int[numLevels];
        speedUpgrades = new float[numLevels];
        gainUpgrades = new float[numLevels];

        int auxH1 = 10,auxH2 =2;
        int auxD = 4;
        int auxG = 4;

        for(int i = 0;i<numLevels;i++)
        {
            levels[i] = (i+1)*10;

            if(i == 2)
            {
                maxHealthUpgrades[i] = 1;
            }

            if(i%2==0 && i >2 && i < 27)
            {
                if(i >= auxH1)
                {
                    auxH2 = auxH2 * 2;
                    auxH1 += 10;
                }
                maxHealthUpgrades[i] = auxH2;
                
            }

            if(i==auxD && i<20)
            {
                damageUpgrades[i] = 1;
                auxD += 5;
            }
            else
            {
                damageUpgrades[i] = 0;
            }

            speedUpgrades[i] = 0.05f;

            if(i == auxG && i < 17)
            {   
                gainUpgrades[i] = 1;
                auxG += 5;
            }
            
        }

        Spawn = GameObject.Find("Spawns");
        coinText = GameObject.Find("TextCoin");
        waveText = GameObject.Find("TextWave");
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
        if(currentLevel%5 == 0)
        {
            speedSpawn = speedSpawn*0.75f;
        }
        Spawn.GetComponent<SpawnEnemy>().attEnemyNum(levels[currentLevel]);
        currentLevel ++;

        waveText.GetComponent<Text>().text = "Wave: " + currentLevel.ToString();
    }

    public bool getCity()
    {
        inCity = !inCity;
        return !inCity;
    }
}
