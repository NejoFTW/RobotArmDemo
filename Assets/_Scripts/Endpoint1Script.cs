using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint1Script : InteractableModuleScript
{
    [SerializeField] Light light;
    Light mainLight;

    private void Awake()
    {
        Light[] allLights = FindObjectsOfType<Light>();
        for (int i = 0; i < allLights.Length; i++)
        {
            Debug.Log("Mamo " + allLights[i].gameObject.name + " ki je " + allLights[i].type.ToString());
            if (allLights[i].type == LightType.Directional)
            {
                mainLight = allLights[i];
                break;
            }
        }

    }

    private void OnEnable()
    {
        light.enabled = false;
    }

    private void OnDisable()
    {
        light.enabled = false;
        if (mainLight != null)
        {
            mainLight.enabled = true;
        }
    }

    public override void Interact()
    {
        base.Interact();
        ToggleLight();
    }

    void ToggleLight()
    {
        light.enabled = !light.enabled;
        if (mainLight != null)
        {
            mainLight.enabled = !light.enabled;
        }
    }
}
