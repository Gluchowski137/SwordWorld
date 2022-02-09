using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour,IEnemy
{
    private HealthBar healthbar;
    private GameObject canvas;
    private GameObject audioManager;
    private AudioManager playerAudio;
    private int maxHealth = 100, currenthealth;

    
    public void TakeDamage(int amount)
    {
        playerAudio.PlayPlayerGotHit();
        currenthealth -= amount;
        healthbar.SetHealth(currenthealth);
        if (currenthealth <= 0)
        { 
            Die();
        }
    }

    void Start()
    {
        GetAudioManager();
        canvas = GameObject.Find("UI");
        healthbar = canvas.GetComponentInChildren<HealthBar>();
        SetHealth();
    }

    void Update()
    {
        
    }
    void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
    }
    void SetHealth()
    {
        currenthealth = maxHealth;
        healthbar.SetMaxHEalth(maxHealth);
    }
    void GetAudioManager()
    {

        audioManager = GameObject.Find("AudioManager");
        playerAudio = audioManager.GetComponent<AudioManager>();
    }

}
