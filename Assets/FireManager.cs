using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireManager : MonoBehaviour
{

    public InputActionReference startFireRef;
    private InputAction startFire;


    // Start is called before the first frame update
    void Start()
    {
        startFire = startFireRef.action;
        startFire.performed += SetFire;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFire(InputAction.CallbackContext context)
    {
        
    }
}
