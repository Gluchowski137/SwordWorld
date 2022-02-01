using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    public int damage = 5;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PerformAttack()
    {
        animator.SetTrigger("BasicAttack");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            
            other.GetComponent<IEnemy>().TakeDamage(damage);
        }
    }
}
