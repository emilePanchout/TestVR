using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headSnap : MonoBehaviour
{
    public FireManager fireManager;
    public bool hasExploded;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RobotHead"))
        {
            hasExploded = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RobotHead") && hasExploded)
        {
            Destroy(other.gameObject);
            fireManager.trueHead.SetActive(true);
            fireManager.hasHead = true;
            Debug.Log("snap");
        }
    }
}
