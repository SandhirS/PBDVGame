using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarPosition : MonoBehaviour
{
    public Rigidbody carRigidbody; // The Rigidbody component of the car
 
    void Start()
    {
        // Ensure the Rigidbody component is assigned
        if (carRigidbody == null)
        {
            Debug.LogError("Please assign the Rigidbody component.");
        }
    }
 
    void Update()
    {
        // Check if the R key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPositionAndRotation();
        }
    }
 
    void ResetPositionAndRotation()
    {
       
        Vector3 currentPosition = carRigidbody.position;
 
        Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y + 5, currentPosition.z);
        carRigidbody.position = newPosition;
 
        
        Quaternion currentRotation = carRigidbody.rotation;
 
        
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0);
        carRigidbody.rotation = newRotation;
 
        
        carRigidbody.velocity = Vector3.zero;
        carRigidbody.angularVelocity = Vector3.zero;
    }
    
}
