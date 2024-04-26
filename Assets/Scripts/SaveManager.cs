using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int heroHP;
    public int currentHeroHP;
    public int heroMP;
    public int currentHeroMP;
    public int manaPotions;
    public int manaPotionsSize;
    public int healPotions;
    public int healSize;
    public int souls;
    public int levelUpCost;
    public int heroStrength;
    public int heroAgility;
    public int heroIntelligence;

    public float dashSpeed = 13f;
    public float jumpForce = 15f;
    public int heroDamage = 15;

    void Start()
    {
        if (PlayerPrefs.HasKey("NewGame") == false)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("NewGame", 1);
        }

        if (PlayerPrefs.HasKey("SetStartValue") == false)
        {
            PlayerPrefs.SetInt("HeroHP", 100);
            PlayerPrefs.SetInt("HeroMP", 100);
            PlayerPrefs.SetInt("CurrentHeroHP", 10);
            PlayerPrefs.SetInt("CurrentHeroMP", 100);
            PlayerPrefs.SetInt("HealPotions", 3);
            PlayerPrefs.SetInt("HealSize", 25);
            PlayerPrefs.SetInt("ManaPotions", 3);
            PlayerPrefs.SetInt("ManaPotionsSize", 35);
            PlayerPrefs.SetInt("Souls", 50000);
            PlayerPrefs.SetInt("LevelUpCost", 50);
            PlayerPrefs.SetInt("HeroStrength", 0);
            PlayerPrefs.SetInt("HeroAgility", 0);
            PlayerPrefs.SetInt("HeroIntelligence", 0);
            PlayerPrefs.SetInt("SetStartValue", 1);
            SetVariables();    
        }
        else
        {
            SetVariables();
        }

        PlayerPrefs.Save();
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
        SetVariables();
    }

    public void SetVariables()
    {
        heroHP = PlayerPrefs.GetInt("HeroHP");
        currentHeroHP = PlayerPrefs.GetInt("CurrentHeroHP");
        heroMP = PlayerPrefs.GetInt("HeroMP");
        currentHeroMP = PlayerPrefs.GetInt("CurrentHeroMP");
        healPotions = PlayerPrefs.GetInt("HealPotions");
        healSize = PlayerPrefs.GetInt("HealSize");
        manaPotions = PlayerPrefs.GetInt("ManaPotions");
        manaPotionsSize = PlayerPrefs.GetInt("ManaPotionsSize");
        souls = PlayerPrefs.GetInt("Souls");
        levelUpCost = PlayerPrefs.GetInt("LevelUpCost");
        heroStrength = PlayerPrefs.GetInt("HeroStrength");
        heroAgility = PlayerPrefs.GetInt("HeroAgility");
        heroIntelligence = PlayerPrefs.GetInt("HeroIntelligence");

        dashSpeed = 13f + heroAgility * 0.5f;
        jumpForce = 15f;
        heroDamage = 15 + heroStrength;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("HeroHP", heroHP);
        PlayerPrefs.SetInt("CurrentHeroHP", currentHeroHP);
        PlayerPrefs.SetInt("HeroMP", heroMP);
        PlayerPrefs.SetInt("CurrentHeroMP", currentHeroMP);
        PlayerPrefs.SetInt("HealPotions", healPotions);
        PlayerPrefs.SetInt("HealSize", healSize);
        PlayerPrefs.SetInt("ManaPotions", manaPotions);
        PlayerPrefs.SetInt("ManaPotionsSize", manaPotionsSize);
        PlayerPrefs.SetInt("Souls", souls);
        PlayerPrefs.SetInt("LevelUpCost", levelUpCost);
        PlayerPrefs.SetInt("HeroStrength", heroStrength);
        PlayerPrefs.SetInt("HeroAgility", heroAgility);
        PlayerPrefs.SetInt("HeroIntelligence", heroIntelligence);
    }
}
