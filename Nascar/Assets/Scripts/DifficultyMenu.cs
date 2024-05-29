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



}
