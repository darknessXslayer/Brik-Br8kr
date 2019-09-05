using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;
    public Vector3 force = new Vector3();

    private Rigidbody rb;
    private bool ballInPlay;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public float adjacentLength = -12f;
    public AudioClip contactSound;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {

            //access the things we are going to change later on
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            GameObject ball = collision.gameObject;

            //gets the positions needed for the angles
            float collisionPosition = collision.transform.position.z;
            float centrepoint = transform.position.z;

            //the magnitude is basically the speed the object is moving
            //it's the length of a vector
            float magnitude = rb.velocity.magnitude;

            //works out opposite length
            float oppositeLength = (collisionPosition - centrepoint);

            //implements equation
            float rotation = Mathf.Atan(oppositeLength / adjacentLength) * Mathf.Rad2Deg;

            //implemtenting result with some added tweaks to get the ball angle in the right
            //direction because 0 degrees in y is facing up
            ball.transform.rotation = Quaternion.Euler(0, rotation - 90, 0);

            //now that the ball is facing the right direction again we set the velocity to be
            //the speed it was going previously but in the new forward facing vector
            rb.velocity = ball.transform.forward * magnitude;
        }
        if(collision.gameObject)
        {
            source.PlayOneShot(contactSound, 1f);
        }
    }
}
