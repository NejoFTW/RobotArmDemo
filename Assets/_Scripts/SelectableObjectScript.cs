using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObjectScript : MonoBehaviour,ISelectable
{
     Material[] highlightMats;
     Material[] originalMats;
    [SerializeField] Material selectedMaterial;
    [SerializeField] Renderer rend;
    RobotHighlightManager highlightManagerScript;


    void Awake()
    {
        if (rend == null)
        {
            rend = GetComponent<Renderer>();
        }

        if (rend == null)
        {
            rend = GetComponentInChildren<Renderer>();
        }
        if (rend == null)
        {
            Debug.Log(this.gameObject.name + "nima rend");
        }
    }

    void Start()
    {
        highlightManagerScript = FindObjectOfType<RobotHighlightManager>();
        highlightManagerScript.ReportToManager(this);
        originalMats = rend.materials;
        int matCount = rend.materials.Length;
        highlightMats = new Material[matCount];
        for (int i = 0; i < matCount; i++)
        {
            highlightMats[i] = selectedMaterial;
        }
    }

    public void Deselect()
    {
        rend.materials = originalMats;
    }

    public void Select()
    {
        highlightManagerScript.DisableAllHighlights();
        rend.materials = highlightMats;
    }
}
