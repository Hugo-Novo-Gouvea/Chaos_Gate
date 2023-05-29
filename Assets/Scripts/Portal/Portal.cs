using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform player, camera;
    private GameObject gameMan;
    
    
    public Vector2 posCamera;
    public GameObject exitPortal;
    public bool city = false;

    void Start()
    {
        gameMan = GameObject.FindWithTag("GameController");
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Vector2 pos = new Vector2(exitPortal.GetComponent<Transform>().position.x + 3f,exitPortal.GetComponent<Transform>().position.y);
        player.position = pos;
        camera.position = new Vector3(posCamera.x,posCamera.y,-10f);
        

        if(city)
        {
            gameMan.GetComponent<GameManager>().newHorde();
            exitPortal.SetActive(false);
        }
    }
}
