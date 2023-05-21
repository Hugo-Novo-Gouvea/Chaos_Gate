using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent navMesh;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(player.transform.position);

    }
}
