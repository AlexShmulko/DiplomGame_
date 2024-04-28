using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private Animator heroAnimator;
    private HeroStates heroStates;
    public PolygonCollider2D heroAttackAreaCollider;

    private int attackAnimationNumber = 1;

    private void Start()
    {
        heroStates = GetComponent<HeroStates>();
        heroAnimator = GetComponent<Animator>();

        heroAttackAreaCollider.enabled = false;
    }

    public void Attack()
    {
        heroStates.isAttacking = true;
        if (attackAnimationNumber != 2)
        {
            attackAnimationNumber++;
        }
        else attackAnimationNumber = 1;
        heroAttackAreaCollider.enabled = true;
        heroAnimator.Play("attack_" + attackAnimationNumber);
    }

    private void StopAttack() // вызывается в конце анимации атаки (attack_1 и attack_2)
    {
        heroStates.isAttacking = false;
        heroAttackAreaCollider.enabled = false;
    }


}
