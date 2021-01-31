using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public int health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            speed = 0;
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }

        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pillow")
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
