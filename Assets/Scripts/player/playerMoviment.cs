using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoviment : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;

    private float timeShoot1 = 0,timeShoot2 = 0;

    
    Rigidbody2D rb;

    public GameObject bullet;
    public Transform bulletPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    
    void Update()
    {
        // Player Moviment
        
        rb.velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x,3.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -3.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-3.5f, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(3.5f, rb.velocity.y);
        }

        // Player Rotation

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        // Player Shoot

        timeShoot1 = Time.time;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(timeShoot1>=timeShoot2)
            {
                Quaternion shootV = transform.rotation;
                shootV.z = shootV.z + Random.Range(-0.05f,0.05f);
                Instantiate(bullet,bulletPos.position,shootV);
                timeShoot1 = Time.time;
                timeShoot2 = Time.time + GetComponent<playerStatus>().getFireRatio();
            }
        }

    }

}
