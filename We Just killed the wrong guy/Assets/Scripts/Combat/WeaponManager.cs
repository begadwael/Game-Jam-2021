using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform spawn;
    [SerializeField] Transform shootAt;
    [SerializeField] BulletHandler handler;
    public Weapon weaponPrefab;
    public Weapon currentWeapon;
    bool respond=true;
    bool active;
    public int ammoLeft;
    float delayTime;
    public Action onShoot;
    void Start()
    {
        StartCoroutine("Create",weaponPrefab);
        InputHandler.instance.onFire2+=ToogleWeapon;
        InputHandler.instance.onReload+=OnReload;
        GetComponent<Pickuper>().onPickup+=Equip;
        GameManager.instance.onGameOver.AddListener(Stop);
        active=true;
    }
    private void Update()
    {
        delayTime=Mathf.Max(0,delayTime-Time.deltaTime);
        if(InputHandler.instance.IsShooting){
            if(delayTime==0){
                OnShoot();
                delayTime=currentWeapon.useDelay;
            }
        }
    }
    public void OnShoot(){
        if(!respond||!active){
            return;
        }
        if(currentWeapon.CanUse()){
            var bullet=currentWeapon.Use(Camera.main,shootAt.position);
            handler.Add(bullet);
            onShoot?.Invoke();
        }else{
            StartCoroutine("Reload");
        }
    }
    public void OnReload(){
        StartCoroutine("Reload");
    }
    public void ToogleWeapon(){
        if(!respond){
            return;
        }
        active=!active;
        StartCoroutine("Toogle");
    }
    public IEnumerator Toogle(){
        respond=false;
        yield return currentWeapon.Set(active);
        respond=true;
    }
    public IEnumerator Reload(){
        if(ammoLeft<=0)yield break;
        respond=false;
        currentWeapon.ReloadAmmo(ref ammoLeft);
        yield return currentWeapon.Reload();
        respond=true;
    }
    public void Equip(Pickup item){
        Weapon prefab=item.item.prefab.GetComponent<Weapon>();
        if(prefab==null){
            return;
        }
        if(!respond){
            GetComponent<Pickuper>().Drop(item);
            return;
        }
        StartCoroutine("Create",prefab);
    }
    IEnumerator Create(Weapon prefab){
        respond=false;
        if(currentWeapon!=null){
            if(active){
                yield return currentWeapon.Deactivate();
            }
            GetComponent<Pickuper>().Drop(currentWeapon.pickup);
            Destroy(currentWeapon.gameObject);
        }
        currentWeapon=Instantiate<Weapon>(prefab,spawn);
        yield return currentWeapon.Activate();
        respond = true;
        delayTime=currentWeapon.useDelay;
    }
    public int GetAmmoInWeapon(){
        return currentWeapon.ammoLeft;
    }
    public  float GetRatio1()
    {
        return (currentWeapon.useDelay-delayTime)/currentWeapon.useDelay;
    }
    public  float GetRatio2()
    {
        return (float)currentWeapon.ammoLeft/(float)currentWeapon.maxAmmo;
    }
    void Stop(string msg){
        respond=false;
    }
}
