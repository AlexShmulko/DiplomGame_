using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHeal : MonoBehaviour
{
    private SaveManager saveManager;
    private HeroStates heroStates;
    private Animator heroAnimator;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        heroStates = GetComponent<HeroStates>();
        heroAnimator = GetComponent<Animator>();
    }

    public void GetHealed()
    {
        if (saveManager.healPotions != 0 && saveManager.currentHeroHP != saveManager.heroHP)
        {
            heroStates.isHealing = true;
            if (saveManager.currentHeroHP + saveManager.healSize < saveManager.heroHP)
            {
                saveManager.currentHeroHP += saveManager.healSize;
            }
            else
            {
                saveManager.currentHeroHP = saveManager.heroHP;
            }
            saveManager.healPotions--;
            heroAnimator.Play("healing");
            saveManager.SaveData();
        }
    }

    private void StopHealing() // вызывается в конце анимации исцеления (healing)
    {
        StartCoroutine(WaitAfterHeal());
        Debug.Log("hello");
        Input.ResetInputAxes();
    }

    IEnumerator WaitAfterHeal()
    {
        yield return new WaitForSeconds(0.3f);
        heroStates.isHealing = false;
    }
}
