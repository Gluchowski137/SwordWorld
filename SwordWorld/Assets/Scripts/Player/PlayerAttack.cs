using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public bool isBlock = false;
    private GetWeapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<GetWeapon>();

    }

    public void NormalAttack()
    {
        if (weapon.isSwordAndShield == true)
        {
            weapon.sword.PerformAttack();
        }
        else if (weapon.isSpear == true)
        {
            weapon.spear.PerformAttack();
        }
        
    }
    public void Shield()
    {
        if (weapon.isSwordAndShield == true)
        {
            isBlock = !isBlock;
            weapon.shield.Block(isBlock);
        }
    }
}

