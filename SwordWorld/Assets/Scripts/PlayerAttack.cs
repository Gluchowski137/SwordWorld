using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    private GameObject spearGameOBject;

    private GetWeapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<GetWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NormalAttack()
    {
        if (weapon.isSwordAndShield == true)
        {
            Debug.Log("I have Sword");
            weapon.sword.PerformAttack();
        }
        else if (weapon.isSpear == true)
        {
            Debug.Log("I have Spear");
            weapon.spear.PerformAttack();
        }
        else
        {
            Debug.Log("I dont have weapon");
        }
        
    }
    public void UpShield()
    {
        if (weapon.isSwordAndShield == true)
        {
            weapon.shield.DoBLock();
        }
    }
    public void DownShield()
    {
        if (weapon.isSwordAndShield == true)
        {
            weapon.shield.UnBLock();
        }
    }
}

