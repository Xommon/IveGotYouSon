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
    public float fireDelay;
    public float fireTimer;
    public float damageDelay;
    public float damageTimer;
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
    public bool hurt;
    public GameObject debugObject;
    public Vector3 debugValues;
    public GameObject heartsUI;
    public GameObject bearsUI;
    public GameObject gameOver;
    public Image end;
    public Image end2;
    public bool fadeToEnd;

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
        hurt = false;
        debugObject = Instantiate(debugObject, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public Vector3 GetMouseWorldPositionOld()
    {
        // Mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);
        print("Aim: " + mousePos2d.normalized);
        return mousePos2d;
    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition;
        Plane plane = new Plane(-Vector3.forward, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            return worldPosition;
        }
        print("this shouldn't happen");
        return new Vector3(0,0,0);
    }

    void FixedUpdate()
    {
        if (fireTimer > 0) fireTimer -= Time.fixedDeltaTime;
        if (damageTimer > 0) damageTimer -= Time.fixedDeltaTime;
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

            if (Input.GetButtonDown("Fire1") && fireTimer<=0)
            {
                Instantiate(pillow, transform.position + new Vector3(0, 0, -0.55f), Quaternion.Euler(new Vector3(0, 0, 0)));
                fireTimer = fireDelay;
            }

            // Decrease vision over time
            vision.transform.localScale -= new Vector3(0.001f, 0.001f, 0);

            if (vision.transform.localScale.x < 1)
            {
                health = 0;
            }

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
            if (Input.GetMouseButtonDown(0))
            {
                Spine.SpineShoot(); 
            }
            if (hurt == true)
            {
                Spine.SpineHit();
                hurt = false;
            }
        }
        else
        {
            if (vision.transform.localScale.x > 0)
            {
                vision.transform.localScale -= new Vector3(0.5f, 0.5f, 0);
            }
            else
            {
                vision.transform.localScale = new Vector3(0, 0, 0);
                heartsUI.SetActive(false);
                bearsUI.SetActive(false);
                gameOver.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TeddyBear")
        {
            bearCount++;
            health++;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Son" && bearCount == 3 && health != 0)
        {
            end.color += new Color(0, 0, 0, 1);

            Invoke("FadeToEnd", 5.0f);

            if (fadeToEnd)
            {
                end2.color += new Color(0, 0, 0, 0.5f);
            }
        }
    }

    void FadeToEnd()
    {
        fadeToEnd = true;
    }

    public void takeDamage(int i) {
        health -= i;
        damageTimer = damageDelay;
        hurt = true;
    }
}