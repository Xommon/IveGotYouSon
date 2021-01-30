using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour {

    public SpriteRenderer sprite;
    public int sort;
    static Vector2 xTranslation = new Vector2(Mathf.Sqrt(2) / 2, Mathf.Sqrt(2) / 2);
    static Vector2 yTranslation = new Vector2(-Mathf.Sqrt(2) / 2, Mathf.Sqrt(2) / 2);

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        sort = (int)((transform.position.x* xTranslation +transform.position.y * yTranslation).x * 10000);
        print(sort);
        sprite.sortingOrder = sort;
    }
}
