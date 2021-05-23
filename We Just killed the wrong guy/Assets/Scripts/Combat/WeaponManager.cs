using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform spawn;
    public Weapon weaponPrefab;
    public Weapon currentWeapon;
    bool respond=true;
    bool active;
    void Start()
    {
        StartCoroutine("Create",weaponPrefab);
        GetComponent<InputHandler>().onFire2+=ToogleWeapon;
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
    IEnumerator Create(Weapon prefab){
        if(currentWeapon!=null){
            Destroy(currentWeapon.gameObject);
        }
        respond=false;
        currentWeapon=Instantiate<Weapon>(prefab,spawn);
        yield return currentWeapon.Activate();
        respond = true;
    }

}
