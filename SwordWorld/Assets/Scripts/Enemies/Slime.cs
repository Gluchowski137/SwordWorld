using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    public int maxhealth, armor, power;
    public int currenthealth;
    public HealthBar healthbar;
    public GameObject explosion;
    private float explosionTime;
    private GameObject audioManager;
    private AudioManager audio;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        audio =   audioManager.GetComponent<AudioManager>();
        currenthealth = maxhealth;
        healthbar.SetMaxHEalth(maxhealth);
        explosionTime = explosion.GetComponentInChildren<ParticleSystem>().main.duration;
    }
    void Die()
    {
        Explode();
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        healthbar.SetHealth(currenthealth);
        if (currenthealth <= 0)
        {
            Die();
        }
    }

    public void Explode()
    {
        audio.PlayExplodeSound();
        GameObject explode = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(explode, explosionTime);
    }
}
