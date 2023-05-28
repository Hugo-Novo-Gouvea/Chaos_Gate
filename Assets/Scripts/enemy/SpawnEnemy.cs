using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy, gameMan;
    public Transform[] Spawns;

    private int enemyNumMax = 0, enemyNum, Rn;
    private bool speed = true;

    float time1, time2;

    public float timeSpawn;

    void Start()
    {
        gameMan = GameObject.FindWithTag("GameController");
        attEnemyNum(10);
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

        if(enemyNum <= enemyNumMax - 5 && speed)
        {
            timeSpawn = timeSpawn/2;
            speed = false;
        }



    }

    public void attEnemyNum(int num)
    {
        enemyNumMax = num;
        enemyNum = enemyNumMax;
        gameMan.GetComponent<GameManager>().maxHealthUp();
        gameMan.GetComponent<GameManager>().damageUp();
        gameMan.GetComponent<GameManager>().speedUp();
        gameMan.GetComponent<GameManager>().gainUp();
    }

    void Spawn(Transform pos)
    {
        Instantiate(enemy, pos.position, transform.rotation);
        enemyNum -= 1;
    }
}
