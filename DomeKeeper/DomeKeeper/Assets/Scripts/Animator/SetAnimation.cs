using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAnimationTrigger(string animation)
    {
        anim.SetTrigger(animation);
    }

    public void SetAnimationBool(string animation, bool check)
    {
        anim.SetBool(animation, check);
    }
}
