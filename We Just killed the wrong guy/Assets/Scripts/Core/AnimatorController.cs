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
        animator.SetFloat("speed",param);
    }
}
