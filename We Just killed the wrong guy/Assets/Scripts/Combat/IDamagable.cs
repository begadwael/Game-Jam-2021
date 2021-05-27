using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public void TakeDamage(int amt);
    public GameObject GetHitVfx();
    public Transform GetObject();
}
