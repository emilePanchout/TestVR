using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    public XRGrabInteractable grab;
    public bool isLaunched = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLaunch()
    {
        Debug.Log("Grenade launched");
        isLaunched = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLaunched && !collision.gameObject.CompareTag("PlayerController"))
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }

}
