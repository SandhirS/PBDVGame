using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{

    public void SelectDifficulty(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {

        
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
