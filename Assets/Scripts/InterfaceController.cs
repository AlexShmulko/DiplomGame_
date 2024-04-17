using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    //public CanvasRenderer healPotion_1;
    //public CanvasRenderer healPotion_2;
    //public CanvasRenderer healPotion_3;

    //public GameObject[] healPotionsUI;
    private SaveManager saveManager;
    private GameObject[] attributeViews;

    public GameObject levelUpWin;

    public bool levelUpWinActiveState = false;

    private int currentHeroStrength;
    private int currentHeroAgility;
    private int currentHeroIntelligence;
    private int currentSouls;
    private int currentLevelUpCost;

    public bool isLevelUpApply = false;

    private void Start()
    {
        levelUpWin.SetActive(false);
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        attributeViews = GameObject.FindGameObjectsWithTag("AttributeView");
        //healPotionsUI = GameObject.FindGameObjectsWithTag("HealPotionUI");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (levelUpWinActiveState)
            {
                if (!isLevelUpApply)
                {
                    PlayerPrefs.SetInt("HeroStrength", currentHeroStrength);
                    PlayerPrefs.SetInt("HeroAgility", currentHeroAgility);
                    PlayerPrefs.SetInt("HeroIntelligence", currentHeroIntelligence);
                    PlayerPrefs.SetInt("Souls", currentSouls);
                    PlayerPrefs.SetInt("LevelUpCost", currentLevelUpCost);
                    saveManager.UpdateAllData();
                }
                levelUpWin.SetActive(false);
            }
            else
            {
                UpdateCurretAttributes();
                levelUpWin.SetActive(true);
            }
            levelUpWinActiveState = !levelUpWinActiveState;
        }
    }

    public void UpdateCurretAttributes()
    {
        currentHeroStrength = saveManager.HeroStrength;
        currentHeroAgility = saveManager.HeroAgility;
        currentHeroIntelligence = saveManager.HeroIntelligence;
        currentSouls = saveManager.Souls;
        currentLevelUpCost = saveManager.LevelUpCost;
    }

    public int CheñkCurrentAttribute(string attribute)
    {
        switch (attribute)
        {
            case "HeroStrength":
                return currentHeroStrength;
            case "HeroAgility":
                return currentHeroAgility;
            case "HeroIntelligence":
                return currentHeroIntelligence;
            default: return 0;
        }
    }
}
