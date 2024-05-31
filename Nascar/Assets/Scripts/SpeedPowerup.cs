using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
   

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        
        
       
        Rigidbody gushesh = other.GetComponent<Rigidbody>();
            
             
           
             Rigidbody m3 = gushesh.GetComponent<Rigidbody>();
             m3.AddForce(gushesh.transform.forward * 500000);                  

            

            
         
        
        Destroy(gameObject);

    } 
}
