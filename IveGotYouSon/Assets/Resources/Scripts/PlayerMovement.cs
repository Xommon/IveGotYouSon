using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveX;
    public float moveY;
    public float speed;
    public int facing;
    public GameObject hitboxStrike;
    public int health;

    static Vector2 xTranslation = new Vector2(1, 1);
    static Vector2 yTranslation = new Vector2(-1, 1);

    Rigidbody2D rigidBody;

    private GameObject PlayerFatherSpine;

    void Start()
    {
        PlayerFatherSpine = GameObject.Find("SpineGameObject");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (health > 0)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
            rigidBody.velocity = speed * (moveX * xTranslation + moveY * yTranslation).normalized;

            if (Input.GetMouseButtonDown(0))
            {
                hitboxStrike.SetActive(true);
                Invoke("DisableHitboxStrike", 0.15f);

                if (moveX == 0 && moveY == 1)
                {
                    facing = 1;
                    hitboxStrike.transform.position = transform.position + new Vector3(-0.5f, 0.5f, 0);
                }
                else if (moveX == 1 && moveY == 1)
                {
                    facing = 2;
                    hitboxStrike.transform.position = transform.position + new Vector3(0, 0.5f, 0);
                }
                else if (moveX == 1 && moveY == 0)
                {
                    facing = 3;
                    hitboxStrike.transform.position = transform.position + new Vector3(0.5f, 0.5f, 0);
                }
                else if (moveX == 1 && moveY == -1)
                {
                    facing = 4;
                    hitboxStrike.transform.position = transform.position + new Vector3(0.5f, 0f, 0);
                }
                else if (moveX == 0 && moveY == -1)
                {
                    facing = 5;
                    hitboxStrike.transform.position = transform.position + new Vector3(0.5f, -0.5f, 0);
                }
                else if (moveX == -1 && moveY == -1)
                {
                    facing = 6;
                    hitboxStrike.transform.position = transform.position + new Vector3(0, -0.5f, 0);
                }
                else if (moveX == -1 && moveY == 0)
                {
                    facing = 7;
                    hitboxStrike.transform.position = transform.position + new Vector3(-0.5f, -0.5f, 0);
                }
                else if (moveX == -1 && moveY == 1)
                {
                    facing = 8;
                    hitboxStrike.transform.position = transform.position + new Vector3(-0.5f, 0, 0);
                }
            }
        }
    }

    void DisableHitboxStrike()
    {
        hitboxStrike.SetActive(false);
    }
}