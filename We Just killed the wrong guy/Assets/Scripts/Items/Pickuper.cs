using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Pickuper : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask pickable;
    [SerializeField] Transform cam;
    public Action<Pickup> onPickup;
    void Start()
    {
        InputHandler.instance.onE+=Pickup;
    }
    public void Pickup(){
        var t=cam;
        var objects =Physics.SphereCastAll(t.position,radius,t.forward,maxDistance,pickable);
        List<Pickup> pickups=new List<Pickup>();
        for (int i = 0; i < objects.Length; i++)
        {
            if(objects[i].collider.TryGetComponent<Pickup>(out Pickup p)){
                pickups.Add(p);
            }
        }
        if(pickups.Count<1){return;}
        var toPickup=pickups[0];
        float minDis=Vector3.Distance(transform.position,toPickup.transform.position);
        for (int i = 0; i < pickups.Count; i++)
        {
            float dis=Vector3.Distance(transform.position,pickups[i].transform.position);
            if(dis<minDis){
                minDis=dis;
                toPickup=pickups[i];
            }
        }
        onPickup?.Invoke(toPickup);
        toPickup.PickupItem();
    }
    public void Drop(Pickup pickup){
        Instantiate<Pickup>(pickup,transform.position+new Vector3(0,.2f,1),Quaternion.identity);
    }
}
