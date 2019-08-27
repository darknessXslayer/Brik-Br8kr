using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;
    public Vector3 force = new Vector3();

    private Rigidbody rb;
    private bool ballInPlay;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            transform.eulerAngles = new Vector3(0, 0, Random.Range(-70, 70));
            force = transform.up;
            rb.AddForce(force * ballInitialVelocity);
        }
    }
}
