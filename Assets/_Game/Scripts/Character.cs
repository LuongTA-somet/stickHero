using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator animator;
    private string currentAnim;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ChangeAnim(string animName)
    {

        if (currentAnim != animName)
        {
            animator.ResetTrigger(animName);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }
   
}
