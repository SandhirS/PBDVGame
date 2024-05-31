using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;


    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void LoadPreviousScene()
    {
        
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {

   
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

