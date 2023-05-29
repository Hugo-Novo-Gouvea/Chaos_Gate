using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEnemy : MonoBehaviour
{
    private GameObject gameMan;

    int currentHealth;

    void Start()
    {
        gameMan = GameObject.FindWithTag("GameController");
        currentHealth =  gameMan.GetComponent<GameManager>().getHealth();
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            gameMan.GetComponent<GameManager>().enemyDead();
            Destroy(gameObject);
        }
    }

    public void dead()
    {
        gameMan.GetComponent<GameManager>().enemyDead();
        Destroy(gameObject);
    }
}
