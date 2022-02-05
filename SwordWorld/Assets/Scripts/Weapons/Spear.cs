using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private int damage = 10;
    private Animator armsAnimator;
    private Animator animator;
    private GameObject humanFps;
    private BoxCollider collider;

    private void Start()
    {
        humanFps = GameObject.Find("HumanFPS");
        armsAnimator = humanFps.GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
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
        collider.enabled = true;
    }
    public void DIsableCollider()
    {
        collider.enabled = false;
    }
}
