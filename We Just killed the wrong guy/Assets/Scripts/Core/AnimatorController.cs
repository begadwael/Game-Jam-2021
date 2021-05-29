using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator=GetComponent<Animator>();
    }
    public void SetSpeed(float param){
        if(animator!=null)
        animator.SetFloat("speed",param);
    }
    public void Die(){
        animator.SetTrigger("Death");
    }
}
