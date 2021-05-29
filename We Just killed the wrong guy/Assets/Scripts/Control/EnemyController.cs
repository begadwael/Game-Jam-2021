using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AIController
{
    [SerializeField] float runAwayRange=20f;
    [SerializeField] float runAwaySpeed=3f;
    protected override IEnumerator Behaviour()
    {
        
        if(InRange(fighter.target.position,detectRange)){
            yield return RunAway();
        }else{
            yield return Wonder();
        }
    }

    protected override IEnumerator Wonder()
    {
        headingPos=GetRandomPos(wonderRange);
        mover.MoveTo(headingPos,normalSpeed);
        while(!InRange(headingPos,stoppingDis)){
            if(InRange(fighter.target.position,detectRange)){
                yield break;
            }
            yield return null;
        }
    }
    IEnumerator RunAway(){
        while(InRange(fighter.target.position,detectRange)){
            headingPos=GetRandomPos(runAwayRange);
            mover.MoveTo(headingPos,runAwaySpeed);
            while(!InRange(headingPos,stoppingDis)){
                yield return null;
            }
        }
    }
}
