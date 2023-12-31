using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyCam : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference switchRef;
    private InputAction switching;

    public InputActionReference clickRef;
    private InputAction clicking;

    public bool onVR = false;

    public Camera flyCam;
    public Camera VRCam;

    public GameObject indicator;

/// <summary>
///	wasd / arrows	- movement
///	q/e 			- up/down (local space)
///	r/f 			- up/down (world space)
///	pageup/pagedown	- up/down (world space)
///	hold shift		- enable fast movement mode
///	right mouse  	- enable free look
///	mouse			- free look / rotation
///	
    public float movementSpeed = 10f;
    public float fastMovementSpeed = 100f;
    public float freeLookSensitivity = 3f;
    public float zoomSensitivity = 10f;
    public float fastZoomSensitivity = 50f;
    private bool looking = false;

    private void Awake()
    {
        VRCam.depth = Camera.main.depth + 1;
    }
    public void Start()
    {
        clicking = clickRef.action;
        clicking.performed += ShowClick;

        switching = switchRef.action;
        switching.performed += Switch;


        onVR = true;
    }
    void Update()
    {
        var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
        {
            transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
        {
            transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }

        float axis = Input.GetAxis("Mouse ScrollWheel");
        if (axis != 0)
        {
            var zoomSensitivity = fastMode ? this.fastZoomSensitivity : this.zoomSensitivity;
            transform.position = transform.position + transform.forward * axis * zoomSensitivity;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartLooking();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopLooking();
        }
    }

    void OnDisable()
    {
        StopLooking();
    }

    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Switch(InputAction.CallbackContext obj)
    {
        if (onVR)
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

    public void ShowClick(InputAction.CallbackContext obj)
    {
        if(onVR)
        {
            Ray ray = VRCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                indicator.transform.position = hit.point;
            }
        }
        else
        {
            Ray ray = flyCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                indicator.transform.position = hit.point;
            }
        }
        
    }
}





