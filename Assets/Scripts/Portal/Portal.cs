using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform player, camera;
    private GameObject gameMan;
    private AudioSource musicD, musicN;
    private float time1=0f,time2=0f;
    
    public Vector2 posCamera;
    public GameObject exitPortal;
    public bool city = false;

    void Start()
    {
        gameMan = GameObject.FindWithTag("GameController");
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        musicD = GameObject.Find("MusicD").GetComponent<AudioSource>();
        musicN = GameObject.Find("MusicN").GetComponent<AudioSource>();
    }

    void Update()
    {
        time1 = Time.time;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(time1>=time2)
        {
            Vector2 pos = new Vector2(exitPortal.GetComponent<Transform>().position.x + 3f,exitPortal.GetComponent<Transform>().position.y);
            player.position = pos;
            camera.position = new Vector3(posCamera.x,posCamera.y,-10f);
            
            if(gameMan.GetComponent<GameManager>().getCity())
            {
                musicD.Play();
                musicN.Stop();
            }
            else
            {
                musicN.Play();
                musicD.Stop();
            }
            if(city)
            {
                gameMan.GetComponent<GameManager>().newHorde();
                exitPortal.SetActive(false);
            }
            time2 = Time.time + 1f;
        }

    }
}
