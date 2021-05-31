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
    public Fighter fighter{get;private set;}
    protected Mover mover;
    public Health health{get{return GetComponent<Health>();}}
    protected Vector3 headingPos;
    protected void Start()
    {
        fighter=GetComponent<Fighter>();
        mover =GetComponent<Mover>();
        StartCoroutine("Begin");
        wonderRange*=wonderRange;
        stoppingDis*=stoppingDis;
        detectRange*=detectRange;
        health.onDie.AddListener(Deactivate);
    }
    IEnumerator Begin(){
        yield return DecideNextState();
    }
    IEnumerator DecideNextState(){
        yield return Behaviour();
        yield return DecideNextState();
    }
    public virtual void Deactivate(){
        if(mover!=null&&mover.enabled)
        mover.Stop();
        StopAllCoroutines();
        enabled=false;
    }
    protected abstract IEnumerator Behaviour();
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
