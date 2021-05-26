using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NpcController : AIController
{
    protected override IEnumerator Behaviour(bool inRange)
    {
       yield return Wonder();
    }

    protected override IEnumerator Wonder()
    {
        headingPos=GetRandomPos(wonderRange);
        mover.MoveTo(headingPos,normalSpeed);
        while(!InRange(headingPos,stoppingDis)){
            yield return null;
        }
    }
}
