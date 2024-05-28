using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boooo : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
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