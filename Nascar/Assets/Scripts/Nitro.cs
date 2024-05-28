using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro
{
    // Start is called before the first frame update

    public Nitro() { }
    public void boooooost(GameObject gushesh, float amt)
    {
        Rigidbody m3 = gushesh.GetComponent<Rigidbody>();
        m3.AddForce(gushesh.transform.forward * amt);
    }
}