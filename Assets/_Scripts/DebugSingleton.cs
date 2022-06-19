using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugSingleton : MonoBehaviour
{
    [SerializeField] GameObject debugPanel;
    public static DebugSingleton instance;
    [SerializeField] TextMeshProUGUI[] texts;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public void WriteDebug(int textId,string newtext)
    {
        debugPanel.SetActive(true);
        texts[textId].text = newtext;
    }
}
