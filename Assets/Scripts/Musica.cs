using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Musica : MonoBehaviour
{
    public AudioClip hurtSound;
    public AudioClip dieSound;
    public AudioClip shootSound;
    private AudioSource _audioSource;
    void Start()
    {
        
    }
    private void Awake()
    {
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
        if (shootSound != null) _audioSource.PlayOneShot(shootSound);
    }

    void Update()
    {
        
    }
}
