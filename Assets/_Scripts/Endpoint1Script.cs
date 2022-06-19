using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint1Script : InteractableModuleScript
{
    [SerializeField] Light light;

    private void OnEnable()
    {
        light.enabled = false;
    }

    public override void Interact()
    {
        base.Interact();
        ToggleLight();
    }

    void ToggleLight()
    {
        light.enabled = !light.enabled;
    }
}
