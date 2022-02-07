using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator armsAnimator;
    private Animator animator;
    private GameObject humanFps;
    private GameObject audioManager;
    private AudioManager swordAudio;
    private BoxCollider swordCollider;

    public int damage = 5;
    void Start()
    {
        
        audioManager = GameObject.Find("AudioManager");
        swordAudio = audioManager.GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
        humanFps = GameObject.Find("HumanFPS");
        armsAnimator = humanFps.GetComponent<Animator>();
        swordCollider = GetComponent<BoxCollider>();
        swordCollider.enabled = false;
    }
    public void EnableCollider()
    {
        swordCollider.enabled = true;
    }
    public void DIsableCollider()
    {
        swordCollider.enabled = false;
    }
    public void PerformAttack() 
    {
        swordAudio.PlayAttackSound();
        armsAnimator.SetTrigger("BasicAttack");
        
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            swordAudio.PlayHitSound();
            other.GetComponent<IEnemy>().TakeDamage(damage);
        }
    }
}
