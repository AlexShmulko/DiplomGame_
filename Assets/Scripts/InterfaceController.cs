using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{

    private SaveManager saveManager;
    private GameObject[] attributeViews;

    public GameObject levelUpWin;

    public bool levelUpWinActiveState = false;

    public bool isLevelUpApply = false;

    public int inventoryItemNumber = 0;

    private void Start()
    {
        levelUpWin.SetActive(false);
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        attributeViews = GameObject.FindGameObjectsWithTag("AttributeView");
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
    }
}
