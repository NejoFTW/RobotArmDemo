using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Endpoint3Script : InteractableModuleScript
{
    [SerializeField] ParticleSystem[] particles;
    public override void Interact()
    {
        base.Interact();
        FireParticles();
    }

    void FireParticles()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Emit(1);
        }
    }

}
