using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject humanFps;
    private Animator armsAnimator;
    private void Start()
    {
        humanFps = GameObject.Find("HumanFPS");
        armsAnimator = humanFps.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void DoBLock()
    {
        armsAnimator.SetBool("Blocking",true);
    }
    public void UnBLock()
    {
        armsAnimator.SetBool("Blocking", false);
    }
}
