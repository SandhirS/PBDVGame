using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTime : MonoBehaviour
{

    public float load_time = 5f;
    void Start()
    {
        StartCoroutine(Waiting_For_Intro());
    }

    IEnumerator Waiting_For_Intro()
    {
        yield return new WaitForSeconds(load_time);

        SceneManager.LoadScene(1);
    }
}
