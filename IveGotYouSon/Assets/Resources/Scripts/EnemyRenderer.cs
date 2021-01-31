using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    public GameObject room;
    WallRenderer wallRenderer;
    public MeshRenderer meshRenderer;

    void Start()
    {
        wallRenderer = room.GetComponent<WallRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.enabled = wallRenderer.playerPresent;
    }
}
