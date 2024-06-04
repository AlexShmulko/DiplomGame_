using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMana : MonoBehaviour
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

    public void GetMana()
    {
        if (saveManager.manaPotions != 0 && saveManager.currentHeroMP != saveManager.heroMP)
        {
            heroStates.isDrinkingMana = true;
            if (saveManager.currentHeroMP + saveManager.manaPotionsSize < saveManager.heroMP)
            {
                saveManager.currentHeroMP += saveManager.manaPotionsSize;
            }
            else
            {
                saveManager.currentHeroMP = saveManager.heroMP;
            }
            saveManager.manaPotions--;
            heroAnimator.Play("manaDrink");
            saveManager.SaveData();
        }
    }

    private void StopGetMana() // вызывается в конце анимации исцеления (healing)
    {
        StartCoroutine(WaitAfterMana());
        Input.ResetInputAxes();
    }

    IEnumerator WaitAfterMana()
    {
        yield return new WaitForSeconds(0.1f);
        heroStates.isDrinkingMana = false;
    }
}
