using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform Spawns1, Spawns2, Spawns3, Spawns4;

    private int enemyNumMax = 0, enemyNum, Rn;
    private bool speed = true;

    float time1, time2;

    public float timeSpawn;

    void Awake()
    {
        attEnemyNum(10);
    }

    void Start()
    {
        enemyNum = enemyNumMax;
    }

    // Update is called once per frame
    void Update()
    {
        time1 = Time.time;

        if(enemyNum > 0 && time1 >= time2 + timeSpawn)
        {
            Rn = Random.Range(1, 5);
            if (Rn == 1)
                Spawn(Spawns1);
            else if (Rn == 2)
                Spawn(Spawns2);
            else if (Rn == 3)
                Spawn(Spawns3);
            else
                Spawn(Spawns4);

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
    }

    void Spawn(Transform pos)
    {
        Instantiate(enemy, pos.position, transform.rotation);
        enemyNum -= 1;
    }
}
