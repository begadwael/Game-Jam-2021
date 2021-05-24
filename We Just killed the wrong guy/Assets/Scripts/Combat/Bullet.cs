using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    public float time;
    public Vector3 initialPoint;
    public Vector3 initialVelocity;
    public TrailRenderer trail;
    public BulletData data;
    public int bounce;
    public Bullet(Vector3 _initialPoint,Vector3 initialVel,BulletData _bulletData){
        initialVelocity=initialVel;
        initialPoint=_initialPoint;
        time=0;
        data=_bulletData;
        bounce=data.maxBounce;
    }
}
[System.Serializable]
public class BulletData{
    public int bulletSpeed;
    public float bulletDrop;
    public float maxLifeTime;
    public int damage;
    public int maxBounce;
    public TrailRenderer bulletTrail;
    public GameObject hitVfx;
}
