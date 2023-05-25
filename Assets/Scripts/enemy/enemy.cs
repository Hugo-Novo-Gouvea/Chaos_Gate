using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{
    private GameObject gameMan, player;
    private NavMeshAgent navMesh;


    // Start is called before the first frame update
    void Start()
    {
        gameMan = GameObject.FindWithTag("GameController");
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(player.transform.position);
        damage();
    }

    void damage()
    {
        GetComponent<statusEnemy>().currentHealth -= 1;
        if(GetComponent<statusEnemy>().currentHealth <= 0)
        {
            gameMan.GetComponent<GameManager>().coin ++;
            Destroy(gameObject);
        }

    }
}
