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
        rigidBody.velocity = direction * speed;
    }
}
