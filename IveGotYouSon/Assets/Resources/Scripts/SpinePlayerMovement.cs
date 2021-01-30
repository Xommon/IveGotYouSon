using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.UIElements;

public class SpinePlayerMovement : MonoBehaviour
{
    [SpineAnimation]
    public string idleAnimationName;
    [SpineAnimation]
    public string walkingAnimationName;
    [SpineAnimation]
    public string hitBackAnimationName;

    public Spine.AnimationState spineAnimationState;
    public SkeletonAnimation skeletonAnimation;
    public Spine.Skeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        spineAnimationState.SetAnimation(0, walkingAnimationName, true, );
    }

    // Update is called once per frame
    void Update()
    {

    }
}

