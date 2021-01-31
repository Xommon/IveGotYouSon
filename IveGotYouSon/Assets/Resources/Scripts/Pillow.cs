using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody2D rigidBody;
    public float speed;
    public Vector3 target;
    public PlayerMovement player;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        target = player.GetMouseWorldPosition();
        Invoke("Delete", 1.0f);
    }

    void FixedUpdate()
    {
        transform.position += Vector3.MoveTowards(transform.position, target, speed/500);
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
