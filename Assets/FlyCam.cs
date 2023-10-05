using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyCam : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    
    public InputActionReference switchRef;
    public InputActionReference movementRef;

    private InputAction movement;
    private InputAction switching;

    public bool onVR = false;

    public Camera flyCam;
    public Camera VRCam;

    void Start()
    {
        switching = switchRef.action;
        switching.performed += Switch;

        movement = movementRef.action;
        movement.performed += Move;

        VRCam.depth = Camera.main.depth + 1;
        onVR = true;

    }


    public void Switch(InputAction.CallbackContext obj)
    {
        if(onVR)
        {
            flyCam.depth = Camera.main.depth + 1;
            onVR = false;
        }
        else
        {
            VRCam.depth = Camera.main.depth + 1;
            onVR = true;
        }
        Debug.Log("switching cam");

    }

    public void Move(InputAction.CallbackContext obj)
    {
        var moveDirection = movement.ReadValue<Vector2>();
    }
}
