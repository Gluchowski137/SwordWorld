using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private GetWeapon getWeapon;
    private void Start()
    {
        getWeapon = GetComponentInParent<GetWeapon>();
    }
    public void EnableSwordCollider()
    {
        getWeapon.sword.EnableCollider();
    }
    public void DisableSwordCollider()
    {
        getWeapon.sword.DIsableCollider();
    }
    public void EnableSpearCollider()
    {
        getWeapon.spear.EnableCollider();
    }
    public void DisableSpearCollider()
    {
        getWeapon.spear.DIsableCollider();
    }
    public void EnableShieldCollider()
    {
        getWeapon.shield.EnableCollider();
    }
    public void DisableShieldCollider()
    {
        getWeapon.shield.DIsableCollider();
    }
    public void InstantiateSword()
    {
        if (!getWeapon.isSwordAndShield)
        {
            getWeapon.GetSwordToHand();
        }    
    }
    public void DestroySword()
    {
        if (getWeapon.isSwordAndShield)
        {
            getWeapon.isSwordAndShield = false;
            Destroy(getWeapon.swordInHand);
            Destroy(getWeapon.shieldInHand);

        }
    }
    public void InstantiateSpear()
    {

        if (!getWeapon.isSpear)
        {
            getWeapon.GetSpearToHand();
        }
    }
    public void DestroySpear()
    {
        if (getWeapon.isSpear)
        {
            getWeapon.isSpear= false;
            Destroy(getWeapon.spearInHand);

        }
    }
}
