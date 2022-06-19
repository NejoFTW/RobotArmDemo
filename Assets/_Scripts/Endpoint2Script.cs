using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint2Script : InteractableModuleScript
{
    public override void Interact()
    {
        base.Interact();
        ToggleLight();
    }

    void ToggleLight()
    {
        GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
    }

}
