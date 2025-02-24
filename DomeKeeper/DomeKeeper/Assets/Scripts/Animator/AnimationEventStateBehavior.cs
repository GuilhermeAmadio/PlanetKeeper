using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventStateBehavior : StateMachineBehaviour
{
    [SerializeField] private string eventName;
    [SerializeField] private int frameEvent, framesInTotal;

    private float timeBetweenFrames, timeFrame;

    private AnimatorClipInfo[] animClipInfo;

    private bool hasTriggered;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasTriggered = false;

        animClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        timeBetweenFrames = animClipInfo[0].clip.length / framesInTotal;
        timeFrame = timeBetweenFrames * frameEvent;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float currentTime = stateInfo.normalizedTime;

        if (!hasTriggered && currentTime >= timeFrame) 
        {
            NotifyReciver(animator);
            hasTriggered = true;
        }
    }

    void NotifyReciver(Animator animator)
    {
        AnimationEventReceiver receiver = animator.GetComponentInChildren<AnimationEventReceiver>();
        if (receiver != null)
        {
            receiver.OnAnimationEventTriggered(eventName);
        }
    }
}
