using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.UIElements;
using System.ComponentModel;

public class SpinePlayerMovement : MonoBehaviour
{
    public Spine.AnimationState spineAnimationState;
    public SkeletonAnimation skeletonAnimation;
    public Spine.Skeleton skeleton;

    [SpineAnimation]
    public string idleAnimationName;
    [SpineAnimation]
    public string walkingAnimationName;
    [SpineAnimation]
    public string hitBackAnimationName;

    [SerializeField]
    private string currentAnimationPlaying;


    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        var spineAnimationState = skeletonAnimation.AnimationState;
        
        spineAnimationState.Event += HandleEvent; ;
        spineAnimationState.End += (entry) => Debug.Log("Start: " + entry.TrackIndex);

        currentAnimationPlaying = walkingAnimationName; 

        spineAnimationState.SetAnimation(0, currentAnimationPlaying, true);
        skeletonAnimation.AnimationName = currentAnimationPlaying;
    }

    void HandleEvent (TrackEntry trackEntry, Spine.Event e)
    {
        Debug.Log(trackEntry.TrackIndex + " " + trackEntry.Animation.Name + "event " + e + ", " + e.Int);
    }

   
    // Update is called once per frame
    void Update()
    {
        StartPlayingWalking();
    }

    public void StartPlayingWalking()
    {
        //skeletonAnimation.AnimationName = walkingAnimationName; 
        //spineAnimationState.AddAnimation(0, walkingAnimationName, true, 0);
    }
}

