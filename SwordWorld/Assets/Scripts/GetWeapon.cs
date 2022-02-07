using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWeapon : MonoBehaviour
{
    private Animator armsAnimator;

    private GameObject swordGameOBject;
    private GameObject spearGameOBject;
    private GameObject shieldGameOBject;

    private GameObject canvas;

    private GameObject closestHandler;

    public GameObject swordInHand;
    public GameObject spearInHand;
    public GameObject shieldInHand;

    private Text getWeaponText;

    private GameObject[] weaponHolders;

    public GameObject swordPrefab;
    public GameObject spearPrefab;
    public GameObject shieldPrefab;

    public GameObject shieldPlace;
    public GameObject swordPlace;
    public GameObject spearPlace;

    public bool isSwordAndShield = false;
    public bool isSpear = false;

    public Sword sword;
    public Spear spear;
    public Shield shield;



    private void Start()
    {
        armsAnimator = GetComponentInChildren<Animator>();
        weaponHolders = GameObject.FindGameObjectsWithTag("WeaponHolder");
        canvas = GameObject.Find("UI");
        getWeaponText = canvas.GetComponentInChildren<Text>();
        getWeaponText.gameObject.SetActive(false);
    }

    private void Update()
    {
        EquipmentText();
    }

    private void EquipmentText()
    {
        if (canGetWeapon())
        {
            if (closestHandler.name == "SwordHandler" || closestHandler.name == "SwordHandler2")
            {
                getWeaponText.text = "To equip Sword  click: E";
            }
            else
            {
                getWeaponText.text = "To equip Spear click: E";
            }
            getWeaponText.gameObject.SetActive(true);
        }
        else
        {
            getWeaponText.gameObject.SetActive(false);
        }
    }
    private bool canGetWeapon()
    {
        foreach (GameObject handler in weaponHolders)
        {
            if ((handler.transform.position - gameObject.transform.position).sqrMagnitude < 5f)
            {
                closestHandler = handler;
                return true;
            }
        }
        return false;
    }
    public void GetWeaponToHand()
    {
        if (canGetWeapon() && (closestHandler.name == "SwordHandler" || closestHandler.name == "SwordHandler2"))
        {
            if (isSpear)
            {
                armsAnimator.SetTrigger("LeaveSpear");
            }

            if (!isSwordAndShield)
            {
                armsAnimator.SetTrigger("GetSword");
            }
            
        }
        if (canGetWeapon() && (closestHandler.name == "SpearHandler" || closestHandler.name == "SpearHandler2"))
        {
            if (isSwordAndShield)
            {
                armsAnimator.SetTrigger("LeaveSword");
            }
            if (!isSpear)
            {
                armsAnimator.SetTrigger("GetSpear");
            }

        }
           
    }
    public void GetSwordToHand()
    {
            swordInHand = Instantiate(swordPrefab, swordPlace.transform);
            shieldInHand = Instantiate(shieldPrefab, shieldPlace.transform);
            isSwordAndShield = true;
            shieldGameOBject = GameObject.FindWithTag("Shield");
            shield = shieldGameOBject.GetComponent<Shield>();
            swordGameOBject = GameObject.FindWithTag("Sword");
            sword = swordGameOBject.GetComponent<Sword>();                
    }
    public void GetSpearToHand()
    {
        spearInHand = Instantiate(spearPrefab, spearPlace.transform);
        isSpear = true;
        spearGameOBject = GameObject.FindWithTag("Spear");
        spear = spearGameOBject.GetComponent<Spear>();
    }


    public void DestroyWeapons()
    {
        isSwordAndShield = false;
        isSpear = false;
    }
}

