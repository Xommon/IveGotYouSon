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
    public SpriteRenderer[] aimDots;
    public SpriteRenderer closestDot;

    static Vector2 xTranslation = new Vector2(1, 1);
    static Vector2 yTranslation = new Vector2(-1, 1);

    public Rigidbody2D rigidBody;

    private GameObject PlayerSpine;

    void Start()
    {
        PlayerSpine = GameObject.Find("SpineGameObject");
        rigidBody = GetComponent<Rigidbody2D>();
        vision.SetActive(true);
        darkness.SetActive(true);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        // Mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
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

        // Shoot direction
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

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
                Vector3 shootDirection;
                shootDirection = Input.mousePosition;
                shootDirection.z = 0.0f;
                shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
                shootDirection = shootDirection - transform.position;
                GameObject newPillow = Instantiate(pillow, transform.position + new Vector3(0, 0, -0.55f), Quaternion.Euler(new Vector3(0, 0, 0)));
                newPillow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * newPillow.GetComponent<Pillow>().speed, shootDirection.y * newPillow.GetComponent<Pillow>().speed);
            }

            // Decrease vision over time
            vision.transform.localScale -= new Vector3(0.001f, 0.001f, 0);

            SpinePlayer Spine = PlayerSpine.GetComponent<SpinePlayer>(); 
            if (moveX == 0 && moveY == 0)
            {
                Spine.SpineStand(); 
            }

            else
            {
                Spine.SpineMove(); 
                if (moveY < 0)
                {
                    Spine.backAnimation = false;
                }
                else
                {
                    Spine.backAnimation = true; 
                }
                if (moveX < 0)
                {
                    Spine.flipAnimation = false; 
                }
                else
                {
                    Spine.flipAnimation = true; 
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TeddyBear")
        {
            bearCount++;
            Destroy(collision.gameObject);
        }
    }
}