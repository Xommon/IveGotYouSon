using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * 0.2f;
    }
}
