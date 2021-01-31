using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToIntroGame : MonoBehaviour
{
 public void NexScene(string scenename)
    {
        Application.LoadLevel (scenename);
        //SceneManager.LoadScene("IntroToGame");
    }
}
