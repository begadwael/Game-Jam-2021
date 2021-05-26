using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] int gameSceneIndex;
    [SerializeField] int optionsSceneIndex;
    [SerializeField] int mainMenuSceneIndex;

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
