using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireManager : MonoBehaviour
{

    public InputActionReference startFireRef;
    private InputAction startFire;

    public List<GameObject> particulesList;
    public int particleIterate =0;
    public GameObject parentHead;
    public GameObject trueHead;
    public GameObject secondHead;


    public bool isOnFire = false;
    public bool hasHead = true;

    // Start is called before the first frame update
    void Start()
    {
        startFire = startFireRef.action;
        startFire.performed += SetFire;
    }


    public void SetFire(InputAction.CallbackContext context)
    {
        if(!isOnFire && hasHead)
        {
            foreach(GameObject fire in particulesList)
            {
                fire.SetActive(true);
            }
           
            trueHead.SetActive(false);

            Instantiate(secondHead, parentHead.transform.position, parentHead.transform.rotation).GetComponent<Rigidbody>().AddForce(100, 100, 100);
            isOnFire = true;
            hasHead = false;
        }
        else
        {
            Debug.Log("Explosion has already occured");
        }
        
    }

    public void StopFire()
    {
        foreach (GameObject fire in particulesList)
        {
            fire.SetActive(false);
            isOnFire = false;
        }
    }

    public void DecreaseFire()
    {

        particulesList[particleIterate].SetActive(false);
        particleIterate += 1;

        if(particleIterate == particulesList.Count)
        {
            particleIterate = 0;
            isOnFire = false;
        }
    }

}
