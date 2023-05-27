using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private GameObject player;

    public float bulletVelocity = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity);
        Destroy(gameObject,3);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<statusEnemy>().takeDamage(player.GetComponent<playerStatus>().getFireDamage());
            Destroy(gameObject);
        }
    }
}
