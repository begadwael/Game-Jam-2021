using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using Control;
public class GameManager : MonoBehaviour
{
    [SerializeField] Vector2Int mapSize;
    [SerializeField] int minNumOfNpc=10;
    [SerializeField] int maxNumOfNpc=20;
    [SerializeField] int maxDeathNpcs=3;
    [SerializeField] int numOfTargets=1;
    [SerializeField] AIController[] npcPrefabs;
    [SerializeField] AIController targetPrefab;
    public static List<AIController> npcs=new List<AIController>();
    public static GameManager instance;
    AIController target;
   [HideInInspector] public Transform player{get;private set;}
    int npcsKilled=0;
    [System.Serializable]
    public  class StringEvent:UnityEvent<string>{
    }
    public StringEvent onGameOver;
    private void Awake()
    {
        if(instance!=null){
            Destroy(this);
        }else{
            instance=this;
        }
        player=GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        int numOfNpcs=Random.Range(minNumOfNpc,maxNumOfNpc);
        for (int i = 0; i < numOfNpcs; i++)
        {
            int posX=Random.Range(-mapSize.x,mapSize.x);
            int posY=Random.Range(-mapSize.y,mapSize.y);
            var npcPrefab=npcPrefabs[Random.Range(0,npcPrefabs.Length)];
            if(NavMesh.SamplePosition(new Vector3(posX,0,posY),out NavMeshHit _hit,mapSize.sqrMagnitude,NavMesh.AllAreas)){
                var npc=Instantiate<AIController>(npcPrefab,_hit.position,Quaternion.identity);
                npcs.Add(npc);
                npc.health.onDie.AddListener(OnNpcKilled);
            }
        }
        if(NavMesh.SamplePosition(new Vector3(Random.Range(-mapSize.x,mapSize.x),0,Random.Range(-mapSize.y,mapSize.y)),out NavMeshHit hit,mapSize.sqrMagnitude,NavMesh.AllAreas)){
            target=Instantiate<AIController>(targetPrefab,hit.position,Quaternion.identity);
            target.health.onDie.AddListener(OnTargetKilled);
        }else{
            throw new System.Exception("Couldnt instantiate target!");
        }
    }
    public void OnTargetKilled(){
        EndGame("Wictory");
    }
    public void OnNpcKilled(){
        npcsKilled++;
        if(npcsKilled==maxDeathNpcs){
            EndGame("You lose!");
        }
    }
    void EndGame(string res){
        onGameOver?.Invoke(res);
        Cursor.lockState=CursorLockMode.None;
        for (int i = 0; i < npcs.Count; i++)
        {
            if(npcs[i]!=null&&npcs[i].enabled)
                npcs[i].Deactivate();
        }
    }
}
