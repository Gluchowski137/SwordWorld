using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;
    private GameObject audioManager;
    private AudioManager audio;

    public int damage = 5;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        audio = audioManager.GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        audio.PlayAttackSound();
        animator.SetTrigger("BasicAttack");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            audio.PlayHitSound();
            other.GetComponent<IEnemy>().TakeDamage(damage);
        }
    }
}
