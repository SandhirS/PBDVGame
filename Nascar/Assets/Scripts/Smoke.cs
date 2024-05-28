using UnityEngine;

public class Smoke : MonoBehaviour
{
    public WheelCollider[] wheelColliders; // Array of wheel colliders
    public ParticleSystem[] smokeParticles; // Array of particle systems for smoke

    void Start()
    {
        // Ensure the arrays are properly set up
        if (wheelColliders.Length != 2 || smokeParticles.Length !=2 )
        {
            Debug.LogError("Please assign exactly 4 WheelColliders and 4 ParticleSystems.");
            return;
        }
        smokeParticles[0].Stop();
        smokeParticles[1].Stop();
    }

    void Update()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            // Check if the wheel is grounded
            if (wheelColliders[i].isGrounded && (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A))))
            {
                // Enable smoke if the wheel is grounded and speed is above a threshold
                if (Mathf.Abs(wheelColliders[i].rpm) >700 ) // Adjust the speed threshold as needed
                {
                    if (!smokeParticles[i].isPlaying)
                    {
                        Debug.Log($"Playing smoke for wheel {i}");
                        smokeParticles[i].Play();
                    }
                }
                
            }
            
        }
    }
}
