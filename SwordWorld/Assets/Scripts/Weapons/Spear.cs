using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private int damage = 10;
    private Animator armsAnimator;
    private Animator animator;
    private GameObject humanFps;
    private BoxCollider spearCollider;

    private void Start()
    {
        humanFps = GameObject.Find("HumanFPS");
        armsAnimator = humanFps.GetComponent<Animator>();
        spearCollider = GetComponent<BoxCollider>();
        spearCollider.enabled = false;
    }
    public void PerformAttack()
    {
        armsAnimator.SetTrigger("SpearAttack");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            other.GetComponent<IEnemy>().TakeDamage(damage);
        }
    }
    public void EnableCollider()
    {
        spearCollider.enabled = true;
    }
    public void DIsableCollider()
    {
        spearCollider.enabled = false;
    }
}
