using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private HeroStats heroStats;

    public int HeroHP;
    public int CurrentHeroHP;
    public int HealPotions;
    public int HealingSize;

    public int Souls;
    public int LevelUpCost;
    public int HeroStrength;
    public int HeroAgility;
    public int HeroIntelligence;

    void Start()
    {
        heroStats = GameObject.Find("Hero").GetComponent<HeroStats>();

        if (PlayerPrefs.HasKey("NewGame") == false)
        {
            Debug.Log("wow");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("NewGame", 1);
        }

        if (PlayerPrefs.HasKey("SetStartValue") == false)
        {
            Debug.Log("new)");
            PlayerPrefs.SetInt("HeroHP", 100);
            PlayerPrefs.SetInt("CurrentHeroHP", 10);
            PlayerPrefs.SetInt("HealPotions", 3);
            PlayerPrefs.SetInt("HealingSize", 25);

            PlayerPrefs.SetInt("Souls", 50000);
            PlayerPrefs.SetInt("LevelUpCost", 50);
            PlayerPrefs.SetInt("HeroStrength", 0);
            PlayerPrefs.SetInt("HeroAgility", 0);
            PlayerPrefs.SetInt("HeroIntelligence", 0);

            PlayerPrefs.SetInt("SetStartValue", 1);
            UpdateAllData();    
        }
        else
        {
            UpdateAllData();
        }

        PlayerPrefs.Save();
        //heroStats.downloadStats();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerPrefs.DeleteKey("NewGame");
        }
    }

    public void UpdateData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
        UpdateAllData();
    }

    public void UpdateAllData()
    {
        HeroHP = PlayerPrefs.GetInt("HeroHP");
        CurrentHeroHP = PlayerPrefs.GetInt("CurrentHeroHP");
        HealPotions = PlayerPrefs.GetInt("HealPotions");
        HealingSize = PlayerPrefs.GetInt("HealingSize");

        Souls = PlayerPrefs.GetInt("Souls");
        LevelUpCost = PlayerPrefs.GetInt("LevelUpCost");
        HeroStrength = PlayerPrefs.GetInt("HeroStrength");
        HeroAgility = PlayerPrefs.GetInt("HeroAgility");
        HeroIntelligence = PlayerPrefs.GetInt("HeroIntelligence");
        heroStats.downloadStats();
    }
}
