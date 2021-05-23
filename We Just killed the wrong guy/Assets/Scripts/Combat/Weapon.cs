using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{
    public Animation animation;
    private void Start()
    {
    }
    public IEnumerator Set(bool active){
        if(active){
            yield return Activate();
        }else{
            yield return Deactivate();
        }
    }
    public IEnumerator Activate(){
        animation["weapon"].speed=1f;
        animation.Play();
        do{
            yield return null;
        }while(animation.isPlaying);
    }
    public IEnumerator Deactivate(){
        animation["weapon"].speed=-1f;
        animation["weapon"].time=animation["weapon"].length;
        animation.Play();
         do{
            yield return null;
        }while(animation.isPlaying);
    }
}
