using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpinePlayer : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset walk,walk_Back, stand, stand_Back, hit, hit_Back;
    public string currentState; 

    // Start is called before the first frame update
    void Start()
    {
        currentState = "Stand";
        SetCharacterState(currentState); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }

    public void SetCharacterState(string state)
    {
        if (state.Equals("Stand"))
        {
            SetAnimation(stand, true, 1f);
        }
        else if (state.Equals("Walk"))
        {
            SetAnimation(walk, true, 1f);
        }
    }

    public void SpineMove()
    {
        SetCharacterState("Walk");

    }
}
