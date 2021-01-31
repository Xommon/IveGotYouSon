using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRenderer : MonoBehaviour {
    public GameObject[] walls;
    public List<SpriteRenderer> wallSprites;
    public SpriteRenderer floor;
    public bool playerPresent;
    float top, bottom, left, right;

    void Start() {
        wallSprites = new List<SpriteRenderer>();
        foreach (GameObject wall in walls) {
            wallSprites.Add(wall.GetComponent<SpriteRenderer>());
        }
        top = transform.position.y - 10;
        bottom = transform.position.y + 10;
        left = transform.position.x - 10;
        right = transform.position.x + 10;
    }

    // Update is called once per frame
    void Update() {
        foreach (SpriteRenderer sprite in wallSprites) {
            sprite.enabled = playerPresent;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        float x = other.transform.position.x;
        float y = other.transform.position.y;
        if (x < left || x >= right || y < top || y >= bottom) {
            playerPresent = false;
        }
        else {
            playerPresent = true;
        }
    }
}
