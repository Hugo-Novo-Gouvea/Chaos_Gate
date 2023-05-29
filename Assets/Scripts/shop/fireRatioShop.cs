using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireRatioShop : MonoBehaviour
{
    public float[] upgrades;
    public int[] cost;
    public int maxUpgrades;

    private GameObject textShop, imageShop;
    private int currentUpgrade = 0;
    private bool imageStatus = false;

    void Start()
    {
        maxUpgrades = upgrades.Length;
        textShop = GameObject.Find("TextFireRShop");
        imageShop = GameObject.Find("ImageFireRShop");

        textShop.GetComponent<Text>().text = cost[currentUpgrade].ToString();

        imageShop.SetActive(false);
    }
    
    public void attFireRShop()
    {
        currentUpgrade++;
        if(currentUpgrade < maxUpgrades)
        {
            textShop.GetComponent<Text>().text = cost[currentUpgrade].ToString();
        }
        else
        {
            textShop.GetComponent<Text>().text = "------------";
        }
    }

    public void interact()
    {
        if(!imageStatus)
        {
            imageShop.SetActive(true);
            imageStatus = true;
        }
        else
        {
            imageShop.SetActive(false);
            imageStatus = false;
        }
    }

    public int getCurrentCost()
    {
        return cost[currentUpgrade];
    }

}
