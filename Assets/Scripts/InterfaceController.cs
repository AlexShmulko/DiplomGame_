using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{

    private SaveManager saveManager;
    private GameObject[] attributeViews;
    private HeroStates heroStates;

    public GameObject levelUpWin;
    public GameObject storeWin;

    public bool isStoreActiv = false;

    public bool levelUpWinActiveState = false;

    public bool isLevelUpApply = false;

    public int inventoryItemNumber = 0;

    private void Start()
    {
        levelUpWin.SetActive(false);
        storeWin.SetActive(false);
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        attributeViews = GameObject.FindGameObjectsWithTag("AttributeView");
        heroStates = GameObject.Find("Hero").GetComponent<HeroStates>();
    }

    private void Update()
    {
        if (!levelUpWinActiveState)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                levelUpWin.SetActive(true);
                levelUpWinActiveState = true;
            }
        }else if (Input.GetKeyDown(KeyCode.H))
        {
            levelUpWin.SetActive(false);
            levelUpWinActiveState = false;
            saveManager.SetVariables();
        }

        if (Input.GetKeyDown(KeyCode.F) && heroStates.inShopZone)
        {
            isStoreActiv = !isStoreActiv;
            storeWin.SetActive(isStoreActiv);
        }
    }
}
