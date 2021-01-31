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

    float attackTimer;
    public float attackDelay;

    private GameObject bookSpine;
    private GameObject vacSpine;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        enemyRenderer = GetComponent<EnemyRenderer>();
        startingPosition = transform.position;

        bookSpine = GameObject.Find("SpineGameObjectBatBook");
        vacSpine = GameObject.Find("SpineGameObjectVacuum");
    }
    // Update is called once per frame
    void Update()
    {

        if (attackTimer > 0) attackTimer -= Time.deltaTime;
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

            SpineVacuum vacspine = vacSpine.GetComponent<SpineVacuum>();
            vacspine.SpineVacWalk();
            if (player.transform.position.x > this.transform.position.x)
            {
                vacspine.flipAnimation = false; 
            }
            else
            {
                vacspine.flipAnimation = true; 
            }
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
            if (player.transform.position.x > this.transform.position.x)
            {
                Spine.flipAnimation = false;
            }
            else
            {
                Spine.flipAnimation = true;
            }
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
        if (collision.transform.tag == "Player" && player.damageTimer <= 0) {
            player.takeDamage(1f);
        }
    }
}
