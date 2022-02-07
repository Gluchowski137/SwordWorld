using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySwordController : MonoBehaviour, IEnemy
{
    [SerializeField] private int maxhealth = 50;
    [SerializeField] private int currenthealth;
    
    public HealthBar healthbar;
    public GameObject explosion;
    private float explosionTime;
    private GameObject audioManager;
    private AudioManager enemySwordAudio;
    private NavMeshAgent agent = null;
    private Animator anim = null;
    private Transform target;
    private GameObject player;
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }
    void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetBool("Walk", true);
        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            AttackTarget();
        }
       

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
    void AttackTarget()
    {
        anim.SetBool("Walk", false);
        anim.SetTrigger("Attack");
    }
    void Die()
    {
        Explode();
        Destroy(gameObject);
    }
    public void Explode()
    {
        enemySwordAudio.PlayExplodeSound();
        GameObject explode = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(explode, explosionTime);
    }
    void GetReferences()
    {
        GetAudioManager();
        explosionTime = explosion.GetComponentInChildren<ParticleSystem>().main.duration;
        player = GameObject.Find("Player");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        SetHealth();
    }
    void SetHealth()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHEalth(maxhealth);
    }
    void GetAudioManager()
    { 
        
        audioManager = GameObject.Find("AudioManager");
        enemySwordAudio = audioManager.GetComponent<AudioManager>();
    }
   
}
