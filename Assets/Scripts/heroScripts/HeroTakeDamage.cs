using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTakeDamage : MonoBehaviour
{

    private SaveManager saveManager;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void TakeDamage(int damage)
    {
        saveManager.currentHeroHP -= damage;
        saveManager.SaveData();
    }

    public void HeroDeath()
    {

    }

}
