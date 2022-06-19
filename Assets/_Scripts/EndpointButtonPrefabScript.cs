using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndpointButtonPrefabScript : MonoBehaviour
{
    int endpointButtonPrefabId = 0;
    [SerializeField] Image buttonIcon;
    [SerializeField] TextMeshProUGUI buttonText;
    MainCanvasControlsScript canvasScript;

    private void Awake()
    {
        canvasScript = GetComponentInParent<MainCanvasControlsScript>();
    }

    public void SetEndpointButton(int buttonId,Sprite  newbuttonIcon,string newButtonText)
    {
        endpointButtonPrefabId = buttonId;
        buttonIcon.sprite = newbuttonIcon;
        buttonText.text = newButtonText;
    }
    public void TriggerAction()
    {
        Debug.Log(this.gameObject.name + " TriggerAction");
        //canvasScript.SetEndPoint(endpointButtonPrefabId);
    }
}
