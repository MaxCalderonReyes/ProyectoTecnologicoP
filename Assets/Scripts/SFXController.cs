using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    public GameObject hurtSound;
    public AudioClip dieSound;
    public AudioClip shootSound;
    public AudioClip jump;
    private AudioSource _audioSource;

    public static SFXController intance;


    private void Awake()
    {
        hurtSound.SetActive(false);
        intance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnHurt()
    {
        hurtSound.SetActive(true);
    }

    public void OnDie()
    {
       
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

