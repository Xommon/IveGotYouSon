using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody2D rigidBody;
    public float speed;
    public Vector2 target;
    public PlayerMovement player;
    bool targetSet = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        target = player.GetMouseWorldPosition();
        Invoke("Delete", 1.0f);
    }

    void FixedUpdate()
    {
        
        rigidBody.velocity = target.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
