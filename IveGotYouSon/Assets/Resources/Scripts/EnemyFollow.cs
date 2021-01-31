﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public int health;
    public float speed;
    public PlayerMovement player;
    public Vector3 startingPosition;
    public EnemyRenderer enemyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        enemyRenderer = GetComponent<EnemyRenderer>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Return the enemy to its starting position if the player leaves the room
        if (player.currentRoom != enemyRenderer.room)
        {
            transform.position = startingPosition;
        }

        if (health < 1)
        {
            speed = 0;
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }

        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed / 500);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pillow")
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
