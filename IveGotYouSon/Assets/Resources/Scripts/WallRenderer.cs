using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class WallRenderer : MonoBehaviour {
    public GameObject[] walls;
    List<SkeletonRenderer> wallSprites;
    bool playerPresent;

    



    void Start() {
        wallSprites = new List<SkeletonRenderer>();
        foreach (GameObject wall in walls) {
            wallSprites.Add(wall.GetComponent<SkeletonRenderer>());
        }
    }

    // Update is called once per frame
    void Update() {
        foreach (SkeletonRenderer sprite in wallSprites)
        {
            sprite.enabled = playerPresent;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerPresent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerPresent = false;
        }
    }
}
