using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShake : MonoBehaviour
{
    public CameraShake cameraShake;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
