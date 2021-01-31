using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public int health;
    public float speed;
    public PlayerMovement player;
    public Vector3 startingPosition;
    public EnemyRenderer enemyRenderer;
    public bool flying;
    public bool attacking;
    public Vector3 foundPosition;

    private GameObject bookSpine;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        enemyRenderer = GetComponent<EnemyRenderer>();
        startingPosition = transform.position;

        bookSpine = GameObject.Find("Spine GameObjectBatBook");
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

        if (!flying)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed / 500);
        }

        if (!attacking && Vector3.Distance(transform.position, player.transform.position) < 7 && flying)
        {
            attacking = true;
            foundPosition = player.transform.position;
            Invoke("StopDash", 1.5f);
        }
        else if (attacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, foundPosition, speed / 500);
            SpineBook Spine = bookSpine.GetComponent<SpineBook>();
            Spine.SpineBookFlyFast();
        }
    }

    void StopDash()
    {
        attacking = false;
        SpineBook Spine = bookSpine.GetComponent<SpineBook>();
        Spine.SpineBookIdle(); 
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
