using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        sprite.sortingOrder = (int)(transform.position.y*1000);
    }
}
