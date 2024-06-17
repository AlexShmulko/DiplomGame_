using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int DEFOLT_POTIONS = 3;
    public int MAX_STONES = 5;

    public int greenStones;
    public int violotStones;
    public int orangeStones;


    public int heroHP;
    public int currentHeroHP;
    public int heroMP;
    public int currentHeroMP;
    public int manaPotions;
    public int manaPotionsSize;
    public int healPotions;
    public int healSize;
    public int maxPotions;
    public int souls;
    public int coins;
    public int levelUpCost;
    public int heroStrength;
    public int heroAgility;
    public int heroIntelligence;

    public float dashSpeed = 13f;
    public float jumpForce = 20f;
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
            PlayerPrefs.SetInt("CurrentHeroHP", 100);
            PlayerPrefs.SetInt("CurrentHeroMP", 100);
            PlayerPrefs.SetInt("HealPotions", 1);
            PlayerPrefs.SetInt("HealSize", 25);
            PlayerPrefs.SetInt("ManaPotions", 1);
            PlayerPrefs.SetInt("ManaPotionsSize", 35);
            PlayerPrefs.SetInt("MaxPotions", DEFOLT_POTIONS);
            PlayerPrefs.SetInt("Souls", 500);
            PlayerPrefs.SetInt("Coins", 5800);
            PlayerPrefs.SetInt("LevelUpCost", 50);
            PlayerPrefs.SetInt("HeroStrength", 0);
            PlayerPrefs.SetInt("HeroAgility", 0);
            PlayerPrefs.SetInt("HeroIntelligence", 0);
            PlayerPrefs.SetInt("SetStartValue", 1);

            PlayerPrefs.SetInt("GreenStones", 0);
            PlayerPrefs.SetInt("VioletStones", 0);
            PlayerPrefs.SetInt("OrangeStones", 0);

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

    public void DeleteSaves()
    {
        PlayerPrefs.DeleteKey("NewGame");
    }

    public void UpdateData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
        SetVariables();
    }

    public void SetVariables()
    {
        greenStones = PlayerPrefs.GetInt("GreenStones");
        violotStones = PlayerPrefs.GetInt("VioletStones");
        orangeStones = PlayerPrefs.GetInt("OrangeStones");

        heroHP = PlayerPrefs.GetInt("HeroHP");
        currentHeroHP = PlayerPrefs.GetInt("CurrentHeroHP");
        heroMP = PlayerPrefs.GetInt("HeroMP");
        currentHeroMP = PlayerPrefs.GetInt("CurrentHeroMP");
        healPotions = PlayerPrefs.GetInt("HealPotions");
        healSize = PlayerPrefs.GetInt("HealSize");
        manaPotions = PlayerPrefs.GetInt("ManaPotions");
        manaPotionsSize = PlayerPrefs.GetInt("ManaPotionsSize");
        maxPotions = PlayerPrefs.GetInt("MaxPotions");
        souls = PlayerPrefs.GetInt("Souls");
        coins = PlayerPrefs.GetInt("Coins");
        levelUpCost = PlayerPrefs.GetInt("LevelUpCost");
        heroStrength = PlayerPrefs.GetInt("HeroStrength");
        heroAgility = PlayerPrefs.GetInt("HeroAgility");
        heroIntelligence = PlayerPrefs.GetInt("HeroIntelligence");

        dashSpeed = 13f + heroAgility * 0.5f;
        jumpForce = 20f;
        heroDamage = 15 + heroStrength;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("GreenStones", greenStones);
        PlayerPrefs.SetInt("VioletStones", violotStones);
        PlayerPrefs.SetInt("OrangeStones", orangeStones);

        PlayerPrefs.SetInt("HeroHP", heroHP);
        PlayerPrefs.SetInt("CurrentHeroHP", currentHeroHP);
        PlayerPrefs.SetInt("HeroMP", heroMP);
        PlayerPrefs.SetInt("CurrentHeroMP", currentHeroMP);
        PlayerPrefs.SetInt("HealPotions", healPotions);
        PlayerPrefs.SetInt("HealSize", healSize);
        PlayerPrefs.SetInt("ManaPotions", manaPotions);
        PlayerPrefs.SetInt("ManaPotionsSize", manaPotionsSize);
        PlayerPrefs.SetInt("MaxPotions", DEFOLT_POTIONS + greenStones);
        PlayerPrefs.SetInt("Souls", souls);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("LevelUpCost", levelUpCost);
        PlayerPrefs.SetInt("HeroStrength", heroStrength);
        PlayerPrefs.SetInt("HeroAgility", heroAgility);
        PlayerPrefs.SetInt("HeroIntelligence", heroIntelligence);

        SetVariables();
    }
}
