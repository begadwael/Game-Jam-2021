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

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    public void Option()
    {
        SceneManager.LoadScene(optionsSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
