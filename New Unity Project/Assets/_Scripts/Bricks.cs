using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1f;

    public GameObject brickParticle;
    public AudioClip contactSound;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject);

        if(collision.gameObject.tag == "Ball")
        {
            GameObject brick = collision.gameObject;
            source.PlayOneShot(contactSound, 1f);
        }
    }
}
