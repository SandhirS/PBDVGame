using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public Camera CameraFov;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "sport_car_1")
        {
            CameraFov.fieldOfView =100;//make camera look faster from car pov
            Destroy(gameObject);
            CarController.maxAcceleration = (float)(CarController.maxAcceleration*1.5);

            
         
        }


    } 
}
