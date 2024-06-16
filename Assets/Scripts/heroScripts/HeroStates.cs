using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStates : MonoBehaviour
{
    private HeroHeal heroHeal;
    private HeroMana heroMane;
    private HeroAttack heroAttack;
    private HeroMove heroMove;
    private Magic magic;

    public bool isJumping;
    public bool isRunning;
    public bool isDashing;
    public bool isFalling;
    public bool isHealing;
    public bool isDrinkingMana;
    public bool isAttacking;
    public bool isDied;


    public bool inActivZone;
    public bool inShopZone;
    public bool inChestZone;

    void Start()
    {
        heroHeal = GetComponent<HeroHeal>();
        heroMane = GetComponent<HeroMana>();
        heroAttack = GetComponent<HeroAttack>();
        heroMove = GetComponent<HeroMove>();
        magic = GetComponent<Magic>();
    }

    public bool HeroEmploymentCheck ()
    {
        if (!isAttacking && !isHealing && !isDrinkingMana && !isDashing && !magic.isCasting && !isJumping)
        {
            return true;
        }
        return false;
    }

    public bool IsHeroInActiveZone()
    {
        if (inChestZone || inShopZone)
        {
            return true;
        }

        return false;
    }


}
