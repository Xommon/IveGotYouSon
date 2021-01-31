using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveX;
    public float moveY;
    public float aimX=1;
    public float aimY=0;
    public float speed;
    public int facing;
    public int health;
    public int bearCount;
    public int level = 1;
    public GameObject vision;
    public GameObject darkness;
    public GameObject[] hearts;
    public GameObject[] bears;
    public Sprite[] heartSprites;
    public Sprite[] bearSprites;
    public GameObject pillow;
    public GameObject currentRoom;

    static Vector2 xTranslation = new Vector2(1, 1);
    static Vector2 yTranslation = new Vector2(-1, 1);

    public Rigidbody2D rigidBody;

    private GameObject PlayerFatherSpine;

    void Start()
    {
        PlayerFatherSpine = GameObject.Find("SpineGameObject");
        rigidBody = GetComponent<Rigidbody2D>();
        vision.SetActive(true);
        darkness.SetActive(true);
    }

    void FixedUpdate()
    {
        // HUD hearts and bears
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health - 1 < i)
            {
                hearts[i].GetComponent<Image>().sprite = heartSprites[1];
            }
            else
            {
                hearts[i].GetComponent<Image>().sprite = heartSprites[0];
            }
        }

        for (int i = 0; i < bears.Length; i++)
        {
            if (bearCount - 1 < i)
            {
                bears[i].GetComponent<Image>().sprite = bearSprites[1];
            }
            else
            {
                bears[i].GetComponent<Image>().sprite = bearSprites[0];
            }
        }

		if (health > 0)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
            rigidBody.velocity = speed * (moveX * xTranslation + moveY * yTranslation).normalized;

            if (moveX != 0 || moveY != 0)
            {
                aimX = moveX;
                aimY = moveY;
            }

            if (Input.GetMouseButtonDown(0))
            {
                
                
                GameObject newPillow = Instantiate(pillow, transform.position + new Vector3(0, 0, -0.55f), Quaternion.identity);
                newPillow.GetComponent<Pillow>().direction = (aimX * xTranslation + aimY * yTranslation).normalized;
            }

            // Decrease vision over time
            vision.transform.localScale -= new Vector3(0.001f, 0.001f, 0);
        }
    }
}