using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    private SaveManager saveManager;
    private Image hpImage;
    public string statName;
    void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        hpImage = GetComponent<Image>();
    }

    void Update()
    {
        if (statName == "hp")
        {
            hpImage.fillAmount = saveManager.currentHeroHP / 100f;
        }else
        {
            hpImage.fillAmount = saveManager.currentHeroMP / 100f;
        }
    }
}
