using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    private SaveManager saveManager;

    // Значения различных статов героя
    //+
    public int heroHP;
    public int healPotion;
    public int healingSize;

    public int souls;
    public int heroStrength;
    public int heroAgility;
    public int heroIntelligence;

    public float dashLength = 3f;
    public float jumpHeight = 3f;
    public int damage = 15;

    void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void downloadStats()
    {
        heroHP = saveManager.CurrentHeroHP;
        healPotion = saveManager.HealPotions;
        healingSize = saveManager.HealingSize;

        souls = saveManager.Souls;
        heroStrength = saveManager.HeroStrength;
        heroAgility = saveManager.HeroAgility;
        heroIntelligence = saveManager.HeroIntelligence;

        dashLength = 3f + heroAgility * 0.2f;
        damage = 15 + heroStrength;
    }
}
