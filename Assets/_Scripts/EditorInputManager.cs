using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EditorInputManager : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    RaycastHit hit;
    ArticulationJointController currentSelectedJoint = null;
    InteractableModuleScript currentInteractableObject = null;
    [SerializeField]GameObject currentlySelectedObject = null;
    [SerializeField] JoystickRobotControls joystickRobotControlScript;
    [SerializeField] MainCanvasControlsScript canvasScript;
    [SerializeField] RobotController robotControllerScript;
    bool hasClickedUi = false;

    private void Awake()
    {
        if (Input.touchSupported)
        {
            this.enabled = false;
        }
    }

    private void Start()
    {
        canvasScript.CloseAllPanels();
    }

    public GameObject GetCurrentSelectedObject()
    {
        return currentlySelectedObject;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasClickedUi = EventSystem.current.IsPointerOverGameObject();
            if (!hasClickedUi)
            {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100))
                {
                    ISelectable selectableScript = hit.collider.gameObject.GetComponent<ISelectable>();
                    if (selectableScript != null)
                    {
                        selectableScript.Select();

                        InteractableModuleScript moduleScript = hit.collider.gameObject.GetComponent<InteractableModuleScript>();
                        ArticulationJointController jointScript = hit.collider.gameObject.GetComponent<ArticulationJointController>();
                        if (moduleScript != null)
                        {
                            Debug.Log("Clicked interactable");
                            currentlySelectedObject = hit.collider.gameObject;
                            canvasScript.ToggleActionPanel(true);

                        }
                        else if (jointScript != null)
                        {
                            currentSelectedJoint = jointScript;
                            canvasScript.ToggleAddButton(true);
                            currentlySelectedObject = null;
                            //
                            canvasScript.ToggleRotationJoystick(true);
                            int elementId = 0;
                            for (int i = 0; i < robotControllerScript.joints.Length; i++)
                            {
                                if (jointScript.gameObject == robotControllerScript.joints[i].robotPart)
                                {
                                    elementId = i;
                                    break;
                                }
                            }
                            joystickRobotControlScript.SelectJoint(elementId);
                        }
                    }
                    else
                    {
                        if (!hasClickedUi)
                        {
                            canvasScript.CloseAllPanels();
                            currentSelectedJoint = null;
                            joystickRobotControlScript.SelectJoint(-1);
                            if (currentInteractableObject != null)
                            {
                                currentInteractableObject.Deselect();
                            }
                            currentInteractableObject = null;
                        }
                    }
                }
            }

        }
    }
}
