using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableModuleScript : SelectableObjectScript
{
    public UnityEvent OnInteract;
    [SerializeField] GameObject snapPoint;

    public GameObject GetSnapPoint()
    {
        return snapPoint;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with : " + this.gameObject.name);
        OnInteract.Invoke();
    }
}
