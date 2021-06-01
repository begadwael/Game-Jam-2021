using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Filler : MonoBehaviour
{
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;

    [SerializeField] WeaponManager filler;
    void Update()
    {
        Fill1(filler.GetRatio1());
        Fill2(filler.GetRatio2());
    }
    public void Fill1(float ratio){
        image1.fillAmount=ratio;
        text1.text=System.Math.Round(filler.delayTime,1).ToString();
    }
    public void Fill2(float ratio){
        image2.fillAmount=ratio;
        text2.text=filler.GetAmmoInWeapon().ToString();
    }
}
