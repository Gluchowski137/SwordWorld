using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private GameObject cam;
    // Start is called before the first frame update
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.gameObject.transform.forward);
    }
}
