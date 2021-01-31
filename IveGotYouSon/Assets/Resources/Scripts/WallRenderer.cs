using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRenderer : MonoBehaviour 
{
    public GameObject[] walls;
    public List<SpriteRenderer> wallSprites;
    public SpriteRenderer floor;
    public GameObject player;
    public PlayerMovement playerMovement;
    public bool playerPresent;
    float top, bottom, left, right;

    void Start() 
    {
        wallSprites = new List<SpriteRenderer>();
        foreach (GameObject wall in walls) 
        {
            wallSprites.Add(wall.GetComponent<SpriteRenderer>());
        }
        top = transform.position.y - 10;
        bottom = transform.position.y + 10;
        left = transform.position.x - 10;
        right = transform.position.x + 10;
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() 
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        playerPresent = !(x < left || x >= right || y < top || y >= bottom);
        foreach (SpriteRenderer sprite in wallSprites) 
        {
            sprite.enabled = playerPresent;
        }

        if (playerPresent)
        {
            playerMovement.currentRoom = this.gameObject;
        }
    }
}
