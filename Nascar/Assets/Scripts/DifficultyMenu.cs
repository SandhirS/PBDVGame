using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DifficultyMenu : MonoBehaviour
{
    public GameObject Canvas;
    

    public void SelectDifficulty(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Canvas.SetActive(false);
        
    }

    public void QuitGame()
    {

        
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
