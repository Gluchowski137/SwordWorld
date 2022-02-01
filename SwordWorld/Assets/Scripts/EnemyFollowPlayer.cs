using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    
    private GameObject player;
    public NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy.speed = 1f;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }
}
