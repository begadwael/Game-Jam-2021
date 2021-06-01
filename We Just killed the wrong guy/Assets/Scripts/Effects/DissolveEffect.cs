using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] float dissolveOffset=10f;
    [SerializeField] float timeBtwOffset=.01f;
    [SerializeField] Material dissolveMat;
    [SerializeField] Health health;
    void Start()
    {
       health.onDie.AddListener(StartEffect); 
    }
    void StartEffect(){
      print("starting!");
      Renderer meshRenderer=GetComponent<Renderer>();
      Material material;
      meshRenderer.materials=new Material[]{dissolveMat};
      material=meshRenderer.materials[0];
      StartCoroutine(Effect(material));
    }
    IEnumerator Effect(Material material){
      float i=3f; 
      while(i>-2f)
      { 
        i-=dissolveOffset/1000;  
        material.SetFloat("_CutoffHeight",i);
        yield return new WaitForSeconds(timeBtwOffset);
      }

    }
}
