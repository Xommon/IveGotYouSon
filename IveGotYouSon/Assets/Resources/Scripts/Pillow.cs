using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody2D rigidBody;
    public float speed;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //rigidBody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
