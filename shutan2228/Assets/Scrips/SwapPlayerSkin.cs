using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlayerSkin : MonoBehaviour
{
    private Animator animator;

    public AnimationClip newIdleAnimation1;
    public AnimationClip newIdleAnimation2;
    public AnimationClip newIdleAnimation3;
    public AnimationClip newIdleAnimation4;
    public AnimationClip newIdleAnimation5;
    public AnimationClip newIdleAnimation6;
    public AnimationClip newIdleAnimation7;
    public AnimationClip newIdleAnimation8;
    public AnimationClip newIdleAnimation9;
    public int index;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (index==0) 
        {
            animator.Play(newIdleAnimation1.name);
        }
        if (index==1) 
        {
            animator.Play(newIdleAnimation2.name);
        }
        if (index==2) 
        {
            animator.Play(newIdleAnimation3.name);
        }
        if (index==3)
        {
            animator.Play(newIdleAnimation4.name);
        }
        if (index==4) 
        {
            animator.Play(newIdleAnimation5.name);
        }
        if (index==5) 
        {
            animator.Play(newIdleAnimation6.name);
        }
        if (index==6) 
        {
            animator.Play(newIdleAnimation7.name);
        }
        if (index==7) 
        {
            animator.Play(newIdleAnimation8.name);
        }
    }

}
