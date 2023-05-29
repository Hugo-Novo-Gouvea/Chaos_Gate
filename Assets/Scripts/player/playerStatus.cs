using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerStatus : MonoBehaviour
{
    GameObject damageShop, fireRatioShop, healthShop,gameMan,EButtonD,EButtonR,EButtonH;
    damageShop nDamageUpgrades;
    fireRatioShop nFireRatioUpgrades;
    healthShop nHealthUpgrades;

    public Image healthBar;
    public float invulnerableTime;
    float timeDamege1, timeDamege2;
    private Vector3 ScalaHealthBar;

    
    public int fireDamage, initialFireDamage, fireDamageUpgradesSum; 
    int currentHealth, maxHealth, initialMaxHealth, maxHealthUpgradesSum;
    float fireRatio, initialFireRatio, fireRatioUpgradesSum;

    int maxDamageUpgrades, maxFireRatioUpgrades, max_HealthUpgrades;

    int damageIncrement, fireRatioIncrement, healthIncrement;
    bool canBuyDamage = false, canBuyFireRatio = false, canBuyHealth = false;

    public int[] fireDamageUpgrades, maxHealthUpgrades;
    public float[] fireRatioUpgrades;

    public string cenaMorte;


    void Start()
    {
        damageShop = GameObject.Find("damageShop");
        nDamageUpgrades = damageShop.GetComponent<damageShop>();

        fireRatioShop = GameObject.Find("fireRatioShop");
        nFireRatioUpgrades = fireRatioShop.GetComponent<fireRatioShop>();

        healthShop = GameObject.Find("healthShop");
        nHealthUpgrades = healthShop.GetComponent<healthShop>();

        gameMan = GameObject.FindWithTag("GameController");

        EButtonD = GameObject.Find("EButtonDamage");
        EButtonD.SetActive(false);

        EButtonR = GameObject.Find("EButtonRatio");
        EButtonR.SetActive(false);

        EButtonH = GameObject.Find("EButtonHealth");
        EButtonH.SetActive(false);


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

        float current = currentHealth,max = maxHealth;
        Vector3 ScalaHealthBar = healthBar.rectTransform.localScale;
        ScalaHealthBar.x = currentHealth/max;
        healthBar.rectTransform.localScale = ScalaHealthBar;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBuyDamage)
        {
            damageShop.GetComponent<damageShop>().interact();
        }
        if (Input.GetKeyDown(KeyCode.E) && canBuyFireRatio)
        {
            fireRatioShop.GetComponent<fireRatioShop>().interact();
        }
        if (Input.GetKeyDown(KeyCode.E) && canBuyHealth)
        {
            healthShop.GetComponent<healthShop>().interact();
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

        damageShop.GetComponent<damageShop>().attDamageShop();
    }

    public void fireRatioUp()
    {
        fireRatioUpgradesSum = 0;

        fireRatioUpgrades[fireRatioIncrement] = nFireRatioUpgrades.upgrades[damageIncrement];

        fireRatioIncrement++;

        for (int i = 0; i < maxFireRatioUpgrades; i++)
        {
            fireRatioUpgradesSum += fireRatioUpgrades[i];
        }

        fireRatio = initialFireRatio + fireRatioUpgradesSum;

        fireRatioShop.GetComponent<fireRatioShop>().attFireRShop();
    }

    public void maxHealthUp()
    {
        maxHealthUpgradesSum = 0;

        maxHealthUpgrades[healthIncrement] = nHealthUpgrades.upgrades[damageIncrement];

        healthIncrement++;

        for (int i = 0; i < max_HealthUpgrades; i++)
        {
            maxHealthUpgradesSum += maxHealthUpgrades[i];
        }

        maxHealth = initialMaxHealth + maxHealthUpgradesSum;

        healthShop.GetComponent<healthShop>().attHealthShop();
    }

    public int getFireDamage()
    {
        return fireDamage;
    }

    public float getFireRatio()
    {
        return fireRatio;
    }

    void takeDamage(int damage)
    {
        if(timeDamege1>= timeDamege2)
        {
            currentHealth -= damage;
            float current = currentHealth,max = maxHealth;
            Vector3 ScalaHealthBar = healthBar.rectTransform.localScale;
            ScalaHealthBar.x = currentHealth/max;
            healthBar.rectTransform.localScale = ScalaHealthBar;
            if(currentHealth <= 0)
            {
                SceneManager.LoadScene(cenaMorte);
            }
            timeDamege2 = Time.time + invulnerableTime;
        }
        timeDamege1 = Time.time;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            takeDamage(gameMan.GetComponent<GameManager>().getDamage());
        }
        if(collider.gameObject.name == "damageShop")
        {
            canBuyDamage = true;
            EButtonD.SetActive(true);
        }
        if(collider.gameObject.name == "fireRatioShop")
        {
            canBuyFireRatio = true;
            EButtonR.SetActive(true);
        }
        if(collider.gameObject.name == "healthShop")
        {
            canBuyHealth= true;
            EButtonH.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.name == "damageShop")
        {
            canBuyDamage = false;
            EButtonD.SetActive(false);
        }
        if(collider.gameObject.name == "fireRatioShop")
        {
            canBuyFireRatio = false;
            EButtonR.SetActive(false);
        }
        if(collider.gameObject.name == "healthShop")
        {
            canBuyHealth= false;
            EButtonH.SetActive(false);
        }
    }
}
