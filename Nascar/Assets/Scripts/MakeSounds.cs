using UnityEngine;

public class CarEngineSound : MonoBehaviour
{
    public AudioSource engineAudioSource; 
    public Rigidbody carRigidbody; 
    public float minPitch = -6f; 
    public float maxPitch = 5f; 
    public float maxSpeed = 200f; 

    void Start()
    {
        if (engineAudioSource == null)
        {
            Debug.LogError("missing audio source");
            return;
        }

        if (carRigidbody == null)
        {
            Debug.LogError("missing rigidbody");
            return;
        }

        engineAudioSource.loop = true; 
        engineAudioSource.Play(); 
    }

    void Update()
    {
        float speed = carRigidbody.velocity.magnitude; 
        float speedPercentage = speed / maxSpeed; 
        engineAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, speedPercentage); 
    }
}
