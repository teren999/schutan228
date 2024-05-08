using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlayerSkin : MonoBehaviour
{
    private Animator animator;

    public AnimationClip[] newIdleAnimation;

    public int index;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(newIdleAnimation[index].name);
    }

}
