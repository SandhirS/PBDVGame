using UnityEngine;

public class CarEngineSound : MonoBehaviour
{
    public AudioSource engineAudioSource; // The AudioSource component playing the engine sound
    public Rigidbody carRigidbody; // The Rigidbody component of the car
    public float minPitch = -6f; // Minimum pitch of the engine sound
    public float maxPitch = 5f; // Maximum pitch of the engine sound
    public float maxSpeed = 200f; // Maximum speed of the car (for pitch scaling)

    void Start()
    {
        if (engineAudioSource == null)
        {
            Debug.LogError("Please assign the AudioSource component.");
            return;
        }

        if (carRigidbody == null)
        {
            Debug.LogError("Please assign the Rigidbody component.");
            return;
        }

        engineAudioSource.loop = true; // Ensure the engine sound loops
        engineAudioSource.Play(); // Start playing the engine sound
    }

    void Update()
    {
        float speed = carRigidbody.velocity.magnitude; // Get the speed of the car
        float speedPercentage = speed / maxSpeed; // Calculate the percentage of the max speed
        engineAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, speedPercentage); // Adjust the pitch
    }
}
