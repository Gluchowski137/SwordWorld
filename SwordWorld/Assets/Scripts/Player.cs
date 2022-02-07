using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IEnemy
{
    private HealthBar healthbar;
    private GameObject canvas;
    private int maxHealth = 100, currenthealth;

    
    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        healthbar.SetHealth(currenthealth);
        if (currenthealth <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        canvas = GameObject.Find("UI");
        healthbar = canvas.GetComponentInChildren<HealthBar>();
        SetHealth();
    }

    void Update()
    {
        
    }
    void Die()
    {
        Debug.Log("DEAD!");
    }
    void SetHealth()
    {
        currenthealth = maxHealth;
        healthbar.SetMaxHEalth(maxHealth);
    }

}
