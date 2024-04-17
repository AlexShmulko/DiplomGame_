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


    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        interfaceController = GameObject.Find("Interface").GetComponent<InterfaceController>();
    }

    public void AttributeBoost(string attribute)
    {
        if(saveManager.Souls - saveManager.LevelUpCost >= 0)
        {
            saveManager.UpdateData(attribute, PlayerPrefs.GetInt(attribute) + 1);
            saveManager.UpdateData("Souls", saveManager.Souls - saveManager.LevelUpCost);
            saveManager.UpdateData("LevelUpCost", saveManager.LevelUpCost + coefficientOfLevelUpCost);
            //attributeView.text = PlayerPrefs.GetInt(attribute).ToString();
            //saveManager.UpdateAllData();
        }
    }

    public void AttributeDowngrade(string attribute)
    {
        if (PlayerPrefs.GetInt(attribute) - 1 >= 0 && PlayerPrefs.GetInt(attribute) - 1 >= interfaceController.CheñkCurrentAttribute(attribute))
        {
            saveManager.UpdateData(attribute, PlayerPrefs.GetInt(attribute) - 1);
            saveManager.UpdateData("LevelUpCost", saveManager.LevelUpCost - coefficientOfLevelUpCost);
            saveManager.UpdateData("Souls", saveManager.Souls + saveManager.LevelUpCost);
            //attributeView.text = PlayerPrefs.GetInt(attribute).ToString();
        }
    }
}
