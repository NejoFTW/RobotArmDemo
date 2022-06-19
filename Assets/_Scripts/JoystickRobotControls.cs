using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRobotControls : MonoBehaviour
{
    [SerializeField]RobotController robotControllerScript;
    [SerializeField] FixedJoystick joystickControlScript;
    float joystickInput;
    int currentSelectedJointId=0;

    private void Update()
    {
        joystickInput = joystickControlScript.Horizontal;
        if (currentSelectedJointId != -1)
        {
            if (joystickInput != 0)
            {
                if (joystickInput > 0)
                {
                    robotControllerScript.RotateJoint(currentSelectedJointId, RotationDirection.Positive);
                }
                else if (joystickInput < 0)
                {
                    robotControllerScript.RotateJoint(currentSelectedJointId, RotationDirection.Negative);
                }
            }
            else
            {
                robotControllerScript.StopAllJointRotations();
            }
        }
    }

    public void SelectJoint(int newJointId)
    {
        currentSelectedJointId = newJointId;
    }
}
