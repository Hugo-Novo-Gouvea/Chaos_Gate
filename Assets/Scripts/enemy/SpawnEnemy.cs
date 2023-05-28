using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy, gameMan, portal;
    public Transform[] Spawns;

    private int enemyNumMax = 0, enemyNum, Rn;
    private bool speed = true;

    float time1, time2;

    public float timeSpawn;

    void Start()
    {
        gameMan = GameObject.FindWithTag("GameController");
        portal = GameObject.Find("PortalStairD");
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time1 = Time.time;

        if(enemyNum > 0 && time1 >= time2 + timeSpawn)
        {
            Rn = Random.Range(0, Spawns.Length);
            Spawn(Spawns[Rn]);

            time2 = Time.time;
        }

        if(gameMan.GetComponent<GameManager>().getNumEnemyDead() >= enemyNumMax)
        {
            portal.SetActive(true);
            gameMan.GetComponent<GameManager>().resetEnemy();
        }

    }

    public void attEnemyNum(int num)
    {
        enemyNumMax = num;
        enemyNum = enemyNumMax;
    }

    void Spawn(Transform pos)
    {
        Instantiate(enemy, pos.position, transform.rotation);
        enemyNum -= 1;
    }
}
