using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPartsManagerScript : MonoBehaviour
{
    [SerializeField] EditorInputManager editorInputScript;
    [SerializeField] TouchInputManager touchInputScript;
    [SerializeField]List<GameObject> customParts;
    public List<GameObject> endPointPrefabs;
    [SerializeField] GameObject snapObject;
    [SerializeField] GameObject extenderPrefab;
    [SerializeField] GameObject currentEndPoint;
    [SerializeField] RobotController robotControllerScript;
    RobotController.Joint[] originalJoints;
    GameObject[] endPointPool;
    int currentEndpointId = 0;
    bool usingExtender = false;

    private void Start()
    {
        customParts = new List<GameObject>();
        endPointPool = new GameObject[endPointPrefabs.Count];
        extenderPrefab = Instantiate(extenderPrefab);
        extenderPrefab.SetActive(false);
        originalJoints = robotControllerScript.joints;
        currentEndpointId = 0;
        for (int i = 0; i < endPointPrefabs.Count; i++)
        {
            GameObject poolObj = Instantiate(endPointPrefabs[i]);
            endPointPool[i] = poolObj;
            poolObj.SetActive(false);
        }
        RebuildPartChain();
    }

    public void ToggleExtender(bool isUsingExtender)
    {
        usingExtender = isUsingExtender;
        RebuildPartChain();
    }

    public void PreviousEndPoint()
    {
        currentEndpointId--;
        if (currentEndpointId < 0)
        {
            currentEndpointId = endPointPool.Length - 1;
        }
        RebuildPartChain();
    }

    public void NextEndPoint()
    {
        currentEndpointId++;
        if (currentEndpointId % endPointPool.Length == 0)
        {
            currentEndpointId = 0;
        }
        RebuildPartChain();
    }


    public void TriggerAction()
    {
        InteractableModuleScript moduleScript;
        if (touchInputScript.enabled)
        {
            moduleScript= touchInputScript.GetCurrentSelectedObject().GetComponent<InteractableModuleScript>();
        }
        else
        {
            moduleScript= editorInputScript.GetCurrentSelectedObject().GetComponent<InteractableModuleScript>();
        }
        Debug.Log("Interacting with : " + moduleScript.gameObject.name);
        moduleScript.Interact();
    }

    void RebuildPartChain()
    {
        Transform endPointParent = snapObject.transform;
        customParts.Clear();
        if (usingExtender)
        {
            endPointParent = extenderPrefab.GetComponent<InteractableModuleScript>().GetSnapPoint().transform;

            extenderPrefab.SetActive(true);
            extenderPrefab.transform.SetParent(snapObject.transform);
            extenderPrefab.transform.localPosition = Vector3.zero;
            extenderPrefab.transform.localEulerAngles = Vector3.zero;
            customParts.Add(extenderPrefab);
        }
        else
        {
            DisableEndPoints();
            extenderPrefab.SetActive(false);
            extenderPrefab.transform.SetParent(null);

        }

        currentEndPoint = endPointPool[currentEndpointId];

        DisableEndPoints();
        currentEndPoint.SetActive(true);
        currentEndPoint.transform.SetParent(endPointParent);

        currentEndPoint.transform.localPosition = Vector3.zero;
        currentEndPoint.transform.localEulerAngles = Vector3.zero;

        customParts.Add(currentEndPoint);
        robotControllerScript.StopAllJointRotations();
        for (int i = 0; i < originalJoints.Length; i++)
        {
            originalJoints[i].robotPart.GetComponent<ArticulationBody>().velocity = Vector3.zero;
        }
    }

    void DisableEndPoints()
    {
        for (int i = 0; i < endPointPool.Length; i++)
        {
            endPointPool[i].SetActive(false);
            endPointPool[i].transform.SetParent(null);
        }
    }
}
