using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.UI;

public class SpineIntro : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset intro;
    public string currentState;
    public string currentAnimation;

    public static TrackEntry trackEntry;

    public GameObject textObject;
    public Color newColor; 
    public float fadeTime = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        trackEntry = skeletonAnimation.AnimationState.GetCurrent(0);
        trackEntry.TrackEnd = trackEntry.Animation.Duration; 
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (trackEntry.IsComplete)
        {
            Application.LoadLevel("Main"); 
        }

        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("Main");
        }
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        Text text = textObject.GetComponent<Text>();
        while (text.color.a > 0)
        {
            text.color = Color.Lerp(text.color, newColor,fadeTime * Time.deltaTime);
            yield return null; 
        }
    }    
}
