using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEnemy : MonoBehaviour
{
    private GameObject gameMan;

    int currentHealth, maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    float speed, initialSpeed, speedUpgradesSum;

    public int maxUpgrades;

    public int[] maxHealthUpgrades;
    public float[] speedUpgrades;



    void Start()
    {
        gameMan = GameObject.FindWithTag("GameController");

        initialMaxHealth = 3;
        initialSpeed = 3;
        currentHealth = initialMaxHealth;

        maxHealthUpgrades = new int[maxUpgrades];
        speedUpgrades = new float[maxUpgrades];

        for (int i = 0; i < maxUpgrades; i++)
        {
            maxHealthUpgrades[i] = 0;
            speedUpgrades[i] = 0;
        }

        maxHealth = initialMaxHealth;
        speed = initialSpeed;

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

    public float getSpeed()
    {
        return speed;
    }

    void damage()
    {
        currentHealth -= 1;
        if(currentHealth <= 0)
        {
            gameMan.GetComponent<GameManager>().coin ++;
            Destroy(gameObject,0);
            Debug.Log("teste");
        }

    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "bullet")
        {
            damage();
        }
    }
}
