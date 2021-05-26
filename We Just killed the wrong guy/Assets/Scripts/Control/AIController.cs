using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class AIController : MonoBehaviour
{
    [SerializeField] protected float wonderRange=10f;
    [SerializeField] protected float stoppingDis=1f;
    [SerializeField] protected float detectRange=10f;
    [Header("MovementData")]
    [SerializeField] protected float normalSpeed=1f;
    protected Fighter fighter;
    protected Mover mover;
    protected Vector3 headingPos;
    private void Start()
    {
        fighter=GetComponent<Fighter>();
        mover=GetComponent<Mover>();
        StartCoroutine("Begin");
        wonderRange*=wonderRange;
        stoppingDis*=stoppingDis;
        detectRange*=detectRange;
    }
    IEnumerator Begin(){
        yield return DecideNextState();
    }
    IEnumerator DecideNextState(){
        bool inRange=InRange(fighter.target.position,detectRange);
        yield return Behaviour(inRange);
        yield return DecideNextState();
    }
    protected abstract IEnumerator Behaviour(bool inRange);
    protected abstract IEnumerator Wonder();
    #region  HelperMethods
    protected Vector3 GetRandomPos(float range){
        return new Vector3(transform.position.x+ UnityEngine.Random.Range(-range,range),transform.position.y,transform.position.z+UnityEngine. Random.Range(-range,range));
    }
    protected bool InRange(Vector3 pos,float range){
        return(pos-transform.position).sqrMagnitude<range;
    }
    #endregion
}
