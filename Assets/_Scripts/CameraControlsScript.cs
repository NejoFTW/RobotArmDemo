using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlsScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Joystick cameraJoystickScript;
    float inputValue;
    // Update is called once per frame
    void FixedUpdate()
    {
        inputValue = cameraJoystickScript.Horizontal;
        if (inputValue != 0)
        {
            transform.LookAt(target);
            transform.Translate(inputValue * Vector3.right * Time.deltaTime);
        }
    }
}
