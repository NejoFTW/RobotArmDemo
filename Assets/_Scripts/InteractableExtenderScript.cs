using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableExtenderScript : InteractableModuleScript
{
    [SerializeField] bool isExtended = true;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        isExtended = !isExtended;
        anim.SetBool("isExtended",isExtended);
    }
}
