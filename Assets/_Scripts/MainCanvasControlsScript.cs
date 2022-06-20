using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasControlsScript : MonoBehaviour
{
    [SerializeField] RobotHighlightManager highlightManager;
    [SerializeField] GameObject rotationPanel;
    [SerializeField] GameObject rotationJoystick;
    [SerializeField] GameObject panelAddingPrefabs;
    [SerializeField] GameObject panelTriggerAction;
    [SerializeField] GameObject buttonAddPrefabs;
    CustomPartsManagerScript partManagerScript;

    private void Start()
    {
        partManagerScript = FindObjectOfType<CustomPartsManagerScript>();
        CloseAllPanels();
    }

    public void CloseAllPanels()
    {
        rotationPanel.SetActive(false);
        rotationJoystick.SetActive(false);
        panelAddingPrefabs.SetActive(false);
        panelTriggerAction.SetActive(false);
        buttonAddPrefabs.SetActive(false);
        ToggleAddButton(false);
    }

    public void ToggleRotationPanel(bool isEnabled)
    {
        CloseAllPanels();
        rotationPanel.SetActive(isEnabled);
    }
    public void ToggleRotationJoystick(bool isEnabled)
    {
        CloseAllPanels();
        buttonAddPrefabs.SetActive(true);
        rotationJoystick.SetActive(isEnabled);
    }
    public void ToggleAddingPanel(bool isEnabled)
    {
        CloseAllPanels();
        panelAddingPrefabs.SetActive(isEnabled);
    }
    public void ToggleActionPanel(bool isEnabled)
    {
        CloseAllPanels();
        panelTriggerAction.SetActive(isEnabled);
        buttonAddPrefabs.SetActive(isEnabled);

    }
    public void ToggleAddButton(bool isEnabled)
    {
        buttonAddPrefabs.SetActive(isEnabled);
    }

    public void TriggerAction(int interactableId)
    {
        Debug.Log("TriggerAction " + interactableId);
        partManagerScript.TriggerAction();
    }

    public void ToggleExtender(bool isUsingExtender)
    {
        partManagerScript.ToggleExtender(isUsingExtender);
    }

    public void SetNextEndPoint()
    {
        partManagerScript.NextEndPoint();
    }    
    public void SetPreviousEndPoint()
    {
        partManagerScript.PreviousEndPoint();
    }    
}
