using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireManager : MonoBehaviour
{

    public InputActionReference startFireRef;
    private InputAction startFire;

    public GameObject particules;
    public GameObject parentHead;
    public GameObject trueHead;
    public GameObject secondHead;

    public bool hasExploded = false;

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
        if(!hasExploded)
        {
            particules.SetActive(true);
            trueHead.SetActive(false);

            Instantiate(secondHead, parentHead.transform.position, parentHead.transform.rotation);
            secondHead.GetComponent<Rigidbody>().AddForce(10, 10, 10);
            hasExploded = true;
        }
        else
        {
            Debug.Log("Explosion has already occured");
        }
        
    }
}
