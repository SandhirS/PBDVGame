using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfwayTriggerScript : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    void OnTriggerEnter()
    {
        LapCompleteTrig.SetActive(true);
        HalfLapTrig.SetActive(false);
    }

}
