using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    protected Rigidbody2D rb;

    private GameObject player;

    private Vector2 DirecaoPlayer;
    private Vector2 novaPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        DirecaoPlayer = new Vector2(player.transform.position.x, player.transform.position.y);
        novaPos = Vector2.MoveTowards(rb.position, DirecaoPlayer, 4 * Time.fixedDeltaTime);
        rb.MovePosition(novaPos);
    }
}
