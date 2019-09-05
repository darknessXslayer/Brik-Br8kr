using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    private AudioSource source;

    public AudioClip wow;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        source.PlayOneShot(wow, 1f);
        GM.instance.LoseLife();
    }
}
