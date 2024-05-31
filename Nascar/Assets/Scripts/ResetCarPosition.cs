using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarPosition : MonoBehaviour
{
    public Rigidbody carRigidbody; 
 
    void Start()
    {
        
        if (carRigidbody == null)
        {
            Debug.LogError("missing RigidBody");
        }
    }
 
    void Update()
    {
        
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
