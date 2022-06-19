using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHighlightManager : MonoBehaviour
{
    [SerializeField]List<ISelectable> allHighlightedObjects;

    private void Awake()
    {
        allHighlightedObjects = new List<ISelectable>();
    }

    public void DisableAllHighlights()
    {
        for (int i = 0; i < allHighlightedObjects.Count; i++)
        {
            allHighlightedObjects[i].Deselect();
        }
    }

    public void ReportToManager(ISelectable selectable)
    {
        allHighlightedObjects.Add(selectable);
    }
}
