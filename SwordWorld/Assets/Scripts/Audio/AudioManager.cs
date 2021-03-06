using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip attackSound;
    public AudioClip hitSound;
    public AudioClip explosionSound;
    public AudioClip playerGetHit;
    public AudioClip getWeapon;

    private AudioSource audioSource;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound,1f);
    }
    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound,1f);
    }
    public void PlayExplodeSound()
    {
        audioSource.PlayOneShot(explosionSound,1f);
    }
    public void PlayPlayerGotHit()
    {
        audioSource.PlayOneShot(playerGetHit, 1f);
    }
    public void PlayeGetWeapon()
    {
        audioSource.PlayOneShot(getWeapon, 1f);
    }
}
