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
    void Start()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHEalth(maxhealth);
        explosionTime = explosion.GetComponentInChildren<ParticleSystem>().main.duration;
    }
    void Die()
    {
        GameObject explode = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Destroy(explode,explosionTime);

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
}
