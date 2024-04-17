using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHeal : MonoBehaviour
{
    private HeroStats heroStats;
    private Animator heroAnimator;
    private SaveManager saveManager;

    public bool isHealing = false;

    private void Start()
    {
        heroStats = GetComponent<HeroStats>();
        heroAnimator = GetComponent<Animator>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void GetHealing()
    {
        if (!isHealing && heroStats.healPotion != 0 && heroStats.heroHP != saveManager.HeroHP)
        {
            isHealing = true;
            if (heroStats.heroHP + heroStats.healingSize < saveManager.HeroHP)
            {
                heroStats.heroHP += heroStats.healingSize;
            }
            else
            {
                heroStats.heroHP = saveManager.HeroHP;
            }
            heroStats.healPotion--;
            heroAnimator.Play("healing");
            Input.ResetInputAxes();
            saveManager.UpdateData("CurrentHeroHP", heroStats.heroHP);
        }
    }

    private void StopHealing() // вызывается в конце анимации исцеления (healing)
    {
        isHealing = false;
    }
}
