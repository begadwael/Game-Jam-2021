using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverMenus : MonoBehaviour
{
    [SerializeField] string mainScene;
    [SerializeField] string thisScene;

    [SerializeField] GameObject menus;
    [SerializeField] TextMeshProUGUI resultText;
    private void Start()
    {
        menus.SetActive(false);
        GameManager.instance.onGameOver.AddListener(Activate);
    }
    public void Activate(string result){
       menus.SetActive(true);
       resultText.text=result;
   }
   public void LoadMainScene(){
       SceneManagment.SceneManager.LoadScene(mainScene);
   }
   public void ReloadScene(){
       SceneManagment.SceneManager.LoadScene(thisScene);
   }
}
