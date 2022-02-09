using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    private int damage = 10;
    private GameObject player;
    private PlayerAttack playerAttack;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        if (playerAttack.isBlock)
        {
            damage = 1;
        }
        else
        {
            damage = 10;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
         other.GetComponent<IEnemy>().TakeDamage(damage);
            
            
        }
    }
}
