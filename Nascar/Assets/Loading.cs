using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public float wait_time = 15f;

    void Start()
    {
        StartCoroutine(waiting_for_intro());
    }

    IEnumerator waiting_for_intro()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(1);
    }
}
