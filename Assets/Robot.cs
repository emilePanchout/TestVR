using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public FireManager fireManager;
    public int particleCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        particleCount += 1;

        Debug.Log("Robot touched by particle");

        if(particleCount == 50)
        {
            particleCount = 0;
            fireManager.DecreaseFire();
        }
    }
}
