using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveX;
    public float moveY;
    public float xVel;
    public float yVel;
    public float speed;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xVel = rigidBody.velocity.x;
        yVel = rigidBody.velocity.y;

        //inputs: is the player moving up or down, left or right
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        //If the player is moving diagonally, we want them to move the same speed that they move the other directions
        if (moveX != 0) xVel = speed * (moveX) / (Mathf.Sqrt(Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2)));
        else xVel = 0;
        if (moveY != 0) yVel = speed * (moveY) / (Mathf.Sqrt(Mathf.Pow(moveX, 2) + Mathf.Pow(moveY, 2)));
        else yVel = 0;

        rigidBody.velocity = new Vector2(xVel, yVel);
    }
}