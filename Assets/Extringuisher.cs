using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Extringuisher : MonoBehaviour
{

    public InputActionReference activateRef;
    private InputAction activate;
    public GameObject particules;

    public bool inHands = false;


    void Start()
    {
        activate = activateRef.action;
        activate.performed += Activate;
        activate.canceled += Deactivate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab()
    {
        inHands = true;
    }

    public void OnDrop()
    {
        inHands = false;
    }

    public void Activate(InputAction.CallbackContext obj)
    {
        if(inHands)
        {
            particules.SetActive(true);
            Debug.Log("button pressed");
        }

    }

    public void Deactivate(InputAction.CallbackContext obj)
    {
        if (inHands)
        {
            particules.SetActive(false);
            Debug.Log("button unpressed");
        }

    }
}
