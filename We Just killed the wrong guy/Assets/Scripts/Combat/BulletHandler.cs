using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    List<Bullet> bullets=new List<Bullet>();
    Ray ray;
    RaycastHit hitInfo;
    public void Add(Bullet bullet){
        bullets.Add(bullet);
    }
    private void Update()
    {
        bullets.ForEach(bullet=>{
            Vector3 p0=GetBulletPosition(bullet);
            bullet.time+=Time.deltaTime;
            Vector3 p1=GetBulletPosition(bullet);
            RaycastSegment(p0,p1,bullet);
        });
        for(int i=0;i<bullets.Count;i++){
            if(bullets[i].time>=bullets[i].data.maxLifeTime){
            bullets.RemoveAt(i);
            }
        }  
    }
    void RaycastSegment(Vector3 startPoint,Vector3 endPoint,Bullet bullet){
        float distance=(endPoint-startPoint).magnitude;
        ray.origin=startPoint;
        ray.direction=endPoint-startPoint;
        if(Physics.Raycast(ray,out hitInfo,distance)){
            CheckForDamagable(bullet,ray,hitInfo);
            bullet.trail.transform.position=hitInfo.point;
            bullet.time=bullet.data.maxLifeTime;
            if(bullet.bounce>0){
                bullet.time=0;
                bullet.initialPoint=hitInfo.point;
                bullet.initialVelocity=Vector3.Reflect(bullet.initialVelocity,hitInfo.normal);
                bullet.bounce--;
            }
        }
        else{
            bullet.trail.transform.position=endPoint;
        }
    }
    void CheckForDamagable(Bullet bullet,Ray _ray,RaycastHit _hit){
        GameObject hitVfxPrefab=bullet.data.hitVfx;
        if(_hit.collider.TryGetComponent<IDamagable>(out IDamagable damagable)){
            print("damage!");
            damagable.TakeDamage(bullet.data.damage);
            hitVfxPrefab=damagable.GetHitVfx();
            if(hitVfxPrefab==null){
                hitVfxPrefab=bullet.data.hitVfx;
            }
        }
        var hitVfx=Instantiate(hitVfxPrefab);
        hitVfx.transform.position=_hit.point;
        hitVfx.transform.forward=_hit.normal;
    }
    Vector3 GetBulletPosition(Bullet bullet){
      Vector3 gravity=Vector3.down*bullet.data.bulletDrop;
      return bullet.initialPoint+(bullet.initialVelocity*bullet.time)+(0.5f*gravity*bullet.time*bullet.time);
    }
}

