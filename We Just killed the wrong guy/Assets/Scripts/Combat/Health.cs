using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamagable
{   
    public int maxHealth=1;
    public UnityEvent onTakeDamage;
    public UnityEvent onDie;
    int health;
    private void Start()
    {
        health=maxHealth;
   
    }
    public GameObject GetHitVfx()
    {
       return null;
    }

    public void TakeDamage(int amt)
    {
        health=Mathf.Max(0,health-amt);
        if(health==0){
            onDie?.Invoke();
            gameObject.SetActive(false);
        }else{
            onTakeDamage?.Invoke();
        }
    }

    public Transform GetObject()
    {
        return transform;
    }
}
