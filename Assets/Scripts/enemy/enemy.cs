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
        navMesh.speed = GetComponent<statusEnemy>().getSpeed();
        navMesh.SetDestination(player.transform.position);

        Vector3 rotation = player.transform.position - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
    }

}
