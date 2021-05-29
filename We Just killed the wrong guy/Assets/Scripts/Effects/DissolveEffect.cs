using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] float dissolveOffset=10f;
    [SerializeField] float timeBtwOffset=.01f;
    [SerializeField] Health health;
    void Start()
    {
       health.onDie.AddListener(StartEffect); 
    }
    void StartEffect(){
      MeshRenderer meshRenderer=GetComponent<MeshRenderer>();
      Material[] materials;
      if(meshRenderer==null)  
      materials=GetComponent<SkinnedMeshRenderer>().materials;
      else materials=meshRenderer.materials;
      StartCoroutine(Effect(materials));
      
    }
    IEnumerator Effect(Material[] materials){
      float i=2f; 
      while(i>-2f)
     { i-=dissolveOffset/1000;  
        foreach(Material material in materials){
          material.SetFloat("_CutoffHeight",i);
          
      }
      yield return new WaitForSeconds(timeBtwOffset);}

    }
}
