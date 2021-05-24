using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponRecoiler : MonoBehaviour
{
    CinemachineImpulseSource cameraShake;
    [SerializeField] Transform cam;
    void Start()
    {
        cameraShake=GetComponent<CinemachineImpulseSource>();
        GetComponent<WeaponManager>().onShoot+=OnShoot;
    }
    public void OnShoot(){
        cameraShake.GenerateImpulse(cam.forward);
    }

}
