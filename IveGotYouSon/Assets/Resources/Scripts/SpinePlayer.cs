using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UIElements;

public class SpinePlayer : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset walk,walk_Back, stand, stand_Back, hit, hit_Back;
    public string currentState;
    public string currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentState = "Stand";
        SetCharacterState(currentState); 
    }

    // Update is called once per frame
    void Update()
    {
 
            SpineMove(); 
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if (animation.name.Equals(currentAnimation))
        {
            return; 
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
        currentAnimation = animation.name; 
    }

    public void SetCharacterState(string state)
    {
        //switch (currentState)
       // {
            //case "stand":
                //SetAnimation(stand, true, 1f);
                //break;
           // case "Walk":
                //SetAnimation(walk, true, 1f);
                //break;

        //}
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetCharacterState("Walk");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            SetCharacterState("Stand");
        }

    }
}
