using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    bool count=true;

    public int seconds;

    private void Start()
    {
        GameManager.instance.onGameOver.AddListener(Stop);
    }
    void Update()
    {
        if(!count){return;}
        seconds=(int)Time.time;
        text.text=$"{seconds/60}:{seconds%60}";
    }
    public void Stop(string s){
        count=false;
    }
}
