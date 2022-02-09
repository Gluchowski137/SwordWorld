using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private GetWeapon getWeapon;
    private GameObject audioManager;
    private AudioManager playSound;
    private void Start()
    {
        GetAudioManager();
        getWeapon = GetComponentInParent<GetWeapon>();
    }
    public void EnableSwordCollider()
    {
        playSound.PlayAttackSound();
        getWeapon.sword.EnableCollider();
    }
    public void DisableSwordCollider()
    {
        getWeapon.sword.DIsableCollider();
    }
    public void EnableSpearCollider()
    {
        playSound.PlayAttackSound();
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
    void GetAudioManager()
    {

        audioManager = GameObject.Find("AudioManager");
        playSound = audioManager.GetComponent<AudioManager>();
    }
}
