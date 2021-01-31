using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineBook : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, fly_Fast;
    public string currentState;
    public string currentAnimation;

    public bool flipAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentState = "Idle";
        SetCharacterState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (state.Equals("Idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        else if (state.Equals("Fly_Fast"))
        {
            SetAnimation(fly_Fast, true, 1.75f); 
        }
    }
    public void SpineBookIdle()
    {
        SetCharacterState("Idle");

        if (flipAnimation == false)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    public void SpineBookFlyFast()
    {
        SetCharacterState("Fly_Fast");
        if (flipAnimation == false)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

}
