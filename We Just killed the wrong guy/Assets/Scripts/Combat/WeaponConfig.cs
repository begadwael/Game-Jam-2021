using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConfig : ScriptableObject
{
   public Pickup pickup;
   public Pickup CreatePickup(Vector3 pos){
      return Instantiate<Pickup>(pickup,pos,Quaternion.identity);
   }
}
