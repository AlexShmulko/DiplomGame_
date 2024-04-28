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
        if (!isAttacking && !isHealing && !isDrinkingMana && !heroMane.isGettingMana && !isDashing && !magic.isCasting && !isJumping)
        {
            return true;
        }
        return false;
    }


}
