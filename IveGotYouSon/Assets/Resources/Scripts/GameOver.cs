using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image fade;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().health <= 0)
        {
            fade.color -= new Color32(0, 0, 0, 1);

            if (fade.color.a <= 0)
            {
                fade.gameObject.SetActive(false);
            }
        }
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
