using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    public AudioClip hurtSound;
    public AudioClip dieSound;
    public AudioClip shootSound;
    public AudioClip jump;
    private AudioSource _audioSource;

    public static SFXController intance;


    private void Awake()
    {
        intance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnHurt()
    {
        if (hurtSound != null) _audioSource.PlayOneShot(hurtSound);
    }

    public void OnDie()
    {
        if (dieSound != null) _audioSource.PlayOneShot(dieSound);
    }

    public void OnShoot()
    {
        if(shootSound!=null) _audioSource.PlayOneShot(shootSound);
    }
    public void OnJump()
    {
        if (jump != null) _audioSource.PlayOneShot(jump);
    }
}

