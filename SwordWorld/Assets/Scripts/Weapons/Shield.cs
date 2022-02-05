using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject humanFps;
    private Animator armsAnimator;
    private BoxCollider collider;
    private void Start()
    {
        humanFps = GameObject.Find("HumanFPS");
        armsAnimator = humanFps.GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
    }
    // Start is called before the first frame update
    public void Block(bool isBlock)
    {
        if (isBlock)
        {
            armsAnimator.SetBool("Blocking", true);

        }
        else
        {
            armsAnimator.SetBool("Blocking", false);
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
