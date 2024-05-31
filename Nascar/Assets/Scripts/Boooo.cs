using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boooo : MonoBehaviour
{
    public float amt;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Nitro shew = new Nitro();
            shew.boooooost(gameObject, amt);
        }
    }
}