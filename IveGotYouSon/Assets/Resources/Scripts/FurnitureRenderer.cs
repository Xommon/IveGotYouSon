using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureRenderer : MonoBehaviour
{
    public GameObject room;
    WallRenderer wallRenderer;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        wallRenderer = room.GetComponent<WallRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.enabled = wallRenderer.playerPresent;
    }
}
