using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWeapon : MonoBehaviour
{
    private GameObject swordGameOBject;
    private GameObject spearGameOBject;
    private GameObject canvas;
    private GameObject closestHandler;
    private GameObject swordInHand;
    private GameObject spearInHand;

    private Text getWeaponText;

    //change this to bool later
    private int closeHolders;

    private GameObject[] weaponHolders;

    public GameObject swordPrefab;
    public GameObject spearPrefab;

    public bool isSword = false;
    public bool isSpear = false;

    public Sword sword;
    public Spear spear;

    

    private void Start()
    {
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
        if (!isSword)
        {
            if (isSpear)
            {
                Destroy(spearInHand);    
            }
            swordInHand = Instantiate(swordPrefab, gameObject.transform);
            isSword = true;
            isSpear = false;
            swordGameOBject = GameObject.FindWithTag("Sword");
            sword = swordGameOBject.GetComponent<Sword>();

        }
        
    }
    void GetSpearToHand()
    {

        if (!isSpear)
        {
            if (isSword)
            {
                Destroy(swordInHand);
            }
            spearInHand = Instantiate(spearPrefab, gameObject.transform);
            isSpear = true;
            isSword = false;
            spearGameOBject = GameObject.FindWithTag("Spear");
            spear = spearGameOBject.GetComponent<Spear>();
        }
        
    }
}

