using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public Camera CameraFov;

    public void OnTriggerEnter(Collider other)
    {
        CarController carController = other.GetComponent<CarController>();
        
        if (other.name == "BMW E30 " )
        {
             CameraFov.fieldOfView =100;//make camera look faster from car pov
             
           
             float newMotorForce = carController.motorForce * 1.5f;
             carController.SetMotorForce(newMotorForce);
             
            
           /* if (carController != null)
            {
                
            }*/

            

            
         
        }
        Destroy(gameObject);

    } 
}
