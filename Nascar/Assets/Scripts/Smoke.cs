using UnityEngine;

public class Smoke : MonoBehaviour
{
    public WheelCollider[] wheelColliders; 
    public ParticleSystem[] smokeParticles; 

    void Start()
    {
        
        if (wheelColliders.Length != 2 || smokeParticles.Length !=2 )
        {
            Debug.LogError("Assign colliders");
            return;
        }
        smokeParticles[0].Stop();
        smokeParticles[1].Stop();
    }

    void Update()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            
            if (wheelColliders[i].isGrounded && (Input.GetKeyDown(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.A))))
            {
                
                if (Mathf.Abs(wheelColliders[i].rpm) >700 )
                {
                    if (!smokeParticles[i].isPlaying)
                    {
                        smokeParticles[i].Play();
                    }
                }
                
            }
            
        }
    }
}
