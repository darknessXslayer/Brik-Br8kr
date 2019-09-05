using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class brickBreak : MonoBehaviour
{
    public AudioClip brick;

    private void Awake()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = brick;
    }

    private void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
