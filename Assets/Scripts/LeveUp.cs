using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeveUp : MonoBehaviour
{
    private SaveManager saveManager;
    private InterfaceController interfaceController;

    public TextMeshProUGUI attributeView;

    private int coefficientOfLevelUpCost = 100;
    private int currentAttriibuteValue;


    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        interfaceController = GameObject.Find("Interface").GetComponent<InterfaceController>();
    }

    public void AttributeBoost(string attribute)
    {
        if(saveManager.souls - saveManager.levelUpCost >= 0)
        {
            switch (attribute)
            {
                case "HeroAgility":
                    saveManager.heroAgility++;
                    break;
                case "HeroStrength":
                    saveManager.heroStrength++;
                    break;
                case "HeroIntelligence":
                    saveManager.heroIntelligence++;
                    break;
            }
            saveManager.souls -= saveManager.levelUpCost;
            saveManager.levelUpCost += coefficientOfLevelUpCost;
        }
    }

    public void AttributeDowngrade(string attribute)
    {
        switch (attribute)
        {
            case "HeroAgility":
                currentAttriibuteValue = saveManager.heroAgility;
                break;
            case "HeroStrength":
                currentAttriibuteValue = saveManager.heroStrength;
                break;
            case "HeroIntelligence":
                currentAttriibuteValue = saveManager.heroIntelligence;
                break;
        }

        if (currentAttriibuteValue - 1 >= PlayerPrefs.GetInt(attribute))
        {
            switch (attribute)
            {
                case "HeroAgility":
                    saveManager.heroAgility--;
                    break;
                case "HeroStrength":
                    saveManager.heroStrength--;
                    break;
                case "HeroIntelligence":
                    saveManager.heroIntelligence--;
                    break;
            }
            saveManager.levelUpCost -= coefficientOfLevelUpCost;
            saveManager.souls += saveManager.levelUpCost;
        }
    }
}
