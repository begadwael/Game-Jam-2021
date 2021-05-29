using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public Transform target;
    private void Start()
    {
        if(target==null){
            target=GameManager.instance.player.transform;
        }
    }
}
