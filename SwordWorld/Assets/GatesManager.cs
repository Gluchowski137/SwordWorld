using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesManager : MonoBehaviour
{
    private Vector3 closePos;
    void Start()
    {
        closePos = transform.parent.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            transform.parent.position = new Vector3(transform.parent.position.x, 5f, transform.parent.position.z);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
             transform.parent.position = closePos;
        }
        
            
    }
}
