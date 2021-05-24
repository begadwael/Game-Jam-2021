using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{
    public int maxAmmo;
    public float useDelay=.3f;
    public Animation animation;
    [SerializeField] Transform shootPoint;
    [SerializeField] BulletData data;
    public Pickup pickup;
    [Header("Anims")]
    public AnimationClip activate;
    public AnimationClip deactivate;
    public AnimationClip reload;
    public UnityEvent onShoot;
    int ammoLeft;
    private void Start()
    {
        ammoLeft=maxAmmo;
    }
    public IEnumerator Set(bool active){
        if(active){
            yield return Activate();
        }else{
            yield return Deactivate();
        }
    }
    public IEnumerator Activate(){
        //animation["weapon"].speed=1f;
        SetAnim(activate);
        animation.Play();
        yield return WaitForAnim();
    }
    public IEnumerator Deactivate(){
       // animation["weapon"].speed=-1f;
       //animation["weapon"].time=animation["weapon"].length;
        SetAnim(deactivate);
        animation.Play();
        yield return WaitForAnim();
    }
     public IEnumerator Reload(){
        ammoLeft=maxAmmo;
        SetAnim(reload);
        animation.Play();
        yield return WaitForAnim();
    }
    IEnumerator WaitForAnim(){
        do{
            yield return null;
        }while(animation.isPlaying);
    }
    public void ReloadAmmo(ref int totalAmmo){
        if(totalAmmo<maxAmmo){
            ammoLeft=totalAmmo;
            totalAmmo=0;
        }else{
            totalAmmo-=maxAmmo-ammoLeft;
            ammoLeft=maxAmmo;
        }
    }
    public Bullet Use(Camera cam,Vector3 vel){
        ammoLeft--;
        var bullet= new Bullet(shootPoint.position,(vel-shootPoint.position).normalized*data.bulletSpeed,data);
        bullet.trail=Instantiate<TrailRenderer>(data.bulletTrail,shootPoint.position,Quaternion.identity);

        onShoot?.Invoke();
        return bullet;
    }
    public void SetAnim(AnimationClip anime){
        animation.clip=anime;
    }
    public bool CanUse(){
        return ammoLeft>0;
    }
}
