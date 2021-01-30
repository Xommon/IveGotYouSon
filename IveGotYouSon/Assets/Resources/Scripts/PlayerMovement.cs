using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveX;
    public float moveY;
    public float speed;

    static Vector2 xTranslation = new Vector2(1, 1);
    static Vector2 yTranslation = new Vector2(-1, 1);

    Rigidbody2D rigidBody;

    public SpinePlayerMovement spine;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnValidate()
    {
        if (spine == null)
        {
            spine = GetComponent<SpinePlayerMovement>();
        }
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        rigidBody.velocity = speed * (moveX * xTranslation + moveY * yTranslation).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Its Working");
        }
    }
}