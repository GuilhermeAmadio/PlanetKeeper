using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    [SerializeField] private List<AnimationEvent> animationEvents = new List<AnimationEvent>();

    public void OnAnimationEventTriggered(string eventName)
    {
        AnimationEvent matchingEvent = animationEvents.Find(se => se.eventName == eventName);
        matchingEvent?.onAnimationEvent?.Invoke();
    }
}
