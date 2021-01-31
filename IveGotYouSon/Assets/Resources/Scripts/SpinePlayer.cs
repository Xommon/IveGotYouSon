using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UIElements;

public class SpinePlayer : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset walk,walk_Back, stand, stand_Back, hit, hit_Back, shoot, shoot_back;
    public string currentState;
    public string currentAnimation;

    public bool backAnimation;
    public bool flipAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentState = "Stand";
        SetCharacterState(currentState); 
    }

    // Update is called once per frame
    void Update()
    {
 
            //SpineMove(); 
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
        else if (state.Equals("Stand_Back"))
        {
            SetAnimation(stand_Back, true, 1f); 
        }
        else if (state.Equals("Walk"))
        {
            SetAnimation(walk, true, 1.8f);
        }
        else if (state.Equals("Walk_Back"))
        {
            SetAnimation(walk_Back, true, 1.8f);
        }
        else if (state.Equals("Shoot"))
        {
            SetAnimation(shoot, true, 1f); 
        }
        else if (state.Equals("Shoot_Back"))
        {
            SetAnimation(shoot_back, true, 1f); 
        }
        else if (state.Equals("Hit"))
        {
            SetAnimation(hit, true, 1f);
        }
        else if (state.Equals("Hit_Back"))
        {
            SetAnimation(hit_Back, true, 1f);
        }
    }

    public void SpineMove()
    {

        if (backAnimation == false)
        {
            SetCharacterState("Walk");
        }
        else
        {
            SetCharacterState("Walk_Back"); 
        }
        if (flipAnimation == false)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
    public void SpineStand ()
    {
        if (backAnimation == false)
        {
            SetCharacterState("Stand");
        }
        else
        {
            SetCharacterState("Stand_Back"); 
        }
    }
    public void SpineShoot()
    {
        if (backAnimation == false)
        {
            SetCharacterState("Shoot");
        }
        else
        {
            SetCharacterState("Shoot_Back"); 
        }
        if (flipAnimation == false)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
    public void SpineHit()
    {
        if (backAnimation == false)
        {
            SetCharacterState("Hit");
        }
        else
        {
            SetCharacterState("Hit_Back");
        }
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
