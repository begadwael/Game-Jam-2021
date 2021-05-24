using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLamp : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] float maxTimeActive=Mathf.Infinity;
    [SerializeField] float maxTimeDisactive=1f;
    bool isActive=true;
    float timer=0;
    float timeToActivate,timeToDeactivate;
    private void Start()
    {
        isActive=true;
        RandomizeTime(ref timeToActivate,maxTimeDisactive);
        RandomizeTime(ref timeToDeactivate,maxTimeActive);
    }
    void FixedUpdate()
    {
        timer+=Time.fixedDeltaTime;
        if(isActive){
            if(timer>timeToDeactivate){
                isActive=false;
                timer=0;
                SetLight(isActive);
                RandomizeTime(ref timeToActivate,maxTimeDisactive);
            }
        }else{
            if(timer>timeToActivate){
                isActive=true;
                timer=0;
                SetLight(isActive);
                RandomizeTime(ref timeToDeactivate,maxTimeActive);
            }
        }
    }
    void SetLight(bool active){
        light.gameObject.SetActive(active);
    }
    void RandomizeTime(ref float time, float max){
        time=Random.Range(max*.8f,max);
    }
}
