using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Pause : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas = null;
    bool isPaused = false;

    private void Start()
    {
        if (pauseCanvas)
        {
            pauseCanvas.enabled = false;    
        }
    }

    private void Update()
    {
        if (pauseCanvas)
        {
            if (Keyboard.current.pKey.wasPressedThisFrame && !isPaused)
            {
                OpenPause();
            }
            else if (Keyboard.current.pKey.wasPressedThisFrame && isPaused)
            {
                ClosePause();
            }
        }
    }

    void OpenPause()
    {
        isPaused = true;
        pauseCanvas.enabled = true;

        Time.timeScale = 0; 
    }

    public void ClosePause()
    {
        isPaused = false;
        pauseCanvas.enabled = false;

        Time.timeScale = 1;
    }
}
