using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace SceneManagment{
public static class SceneManager
{
    public static void LoadScene(string name){
        try{
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }catch{
            Debug.Log("Couldnt load the scene!");
        }
    }
}
}