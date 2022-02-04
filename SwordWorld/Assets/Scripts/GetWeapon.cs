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

    private GameObject swordInHand;
    private GameObject spearInHand;
    private GameObject shieldInHand;

    private Text getWeaponText;

    //change this to bool later
    private int closeHolders;

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
        closeHolders = 0;
        foreach(GameObject handler in weaponHolders)
        {
            if ((handler.transform.position - gameObject.transform.position).sqrMagnitude < 5f)
            {
                closestHandler = handler;
                closeHolders++;            
            }
        }
        if(closeHolders > 0)
        {
            if (closestHandler.name == "SwordHandler" || closestHandler.name == "SwordHandler2"){
                getWeaponText.text = "To equip Sword click: E";
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

    public void GetWeaponToHand()
    {
        if (closeHolders > 0 && (closestHandler.name == "SwordHandler" || closestHandler.name == "SwordHandler2"))
        {
            GetSwordToHand();
            armsAnimator.SetTrigger("GetSword");
            Debug.Log("SWord");
            
        }
        if (closeHolders > 0 && (closestHandler.name == "SpearHandler" || closestHandler.name == "SpearHandler2"))
        {
            GetSpearToHand();
        }
        else
        {
            Debug.Log("Cant");
        }
           
    }
    void GetSwordToHand()
    {
        if (!isSwordAndShield)
        {
            if (isSpear)
            {
                Destroy(spearInHand);    
            }
            swordInHand = Instantiate(swordPrefab, swordPlace.transform);
            shieldInHand = Instantiate(shieldPrefab, shieldPlace.transform);
            isSwordAndShield = true;
            isSpear = false;
            swordGameOBject = GameObject.FindWithTag("Sword");
            sword = swordGameOBject.GetComponent<Sword>();
            shieldGameOBject = GameObject.FindWithTag("Shield");
            shield = shieldGameOBject.GetComponent<Shield>();

        }
        
    }
    void GetSpearToHand()
    {

        if (!isSpear)
        {
            if (isSwordAndShield)
            {
                Destroy(swordInHand);
                Destroy(shieldInHand);
            }
            spearInHand = Instantiate(spearPrefab, spearPlace.transform);
            isSpear = true;
            isSwordAndShield = false;
            spearGameOBject = GameObject.FindWithTag("Spear");
            spear = spearGameOBject.GetComponent<Spear>();
        }
        
    }
}

