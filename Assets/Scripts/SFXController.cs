using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    public GameObject hurtSound;
    public AudioClip dieSound;
    public GameObject shootSound;
    public GameObject jump;
    private AudioSource _audioSource;

    public static SFXController intance;


    private void Awake()
    {
        hurtSound.SetActive(false);
        jump.SetActive(false);
        shootSound.SetActive(false);
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
        shootSound.SetActive(true);
    }
    public void OnJump()
    {
        jump.SetActive(true);
    }
    public void OffJump()
    {
        jump.SetActive(false);
    }
    public void OffShoot()
    {
        shootSound.SetActive(false);
    }
}

