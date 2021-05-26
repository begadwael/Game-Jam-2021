using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mover : MonoBehaviour
{
    NavMeshAgent agent;
    private void Awake()
    {
        agent=GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    public void MoveTo(Vector3 pos, float speed){
        if(NavMesh.SamplePosition(pos,out NavMeshHit hit,5f,NavMesh.AllAreas)){
            agent.destination=hit.position;
            agent.speed=speed;
            agent.isStopped=false;
        }
    }
    public void Stop(){
        agent.isStopped=true;
    }
}
