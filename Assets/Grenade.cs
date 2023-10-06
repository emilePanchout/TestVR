using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    public XRGrabInteractable grab;
    public bool isLaunched = false;

    public GameObject grenadePrefab;
    public Transform grenadeSpawn;
    public GameObject particules;
    public GameObject robot;
    public FireManager fireManager;
    public float explosionRadius;
    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.Find("tiago_dual");
        fireManager = GameObject.Find("XR Origin (XR Rig)").GetComponent<FireManager>();
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
        if (isLaunched && !collision.gameObject.CompareTag("PlayerController") && !collision.gameObject.CompareTag("GrenadeTable"))
        {
            Instantiate(particules, transform.position, transform.rotation);

            if (explosionRadius > Vector3.Distance(transform.position,robot.transform.position))
            {
                fireManager.StopFire();
            }

            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);

            //Instantiate(grenadePrefab, grenadeSpawn.transform.position, grenadeSpawn.rotation);
        }
    }


}


