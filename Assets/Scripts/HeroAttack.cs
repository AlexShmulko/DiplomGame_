using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private Animator heroAnimator;
    private HeroMove heroMove;
    [SerializeField] private PolygonCollider2D heroAttackAreaCollider;

    private int attackAnimationNumber = 1;
    public bool isAttacking = false;

    private void Start()
    {
        heroAnimator = GetComponent<Animator>();
        heroMove = GetComponent<HeroMove>();
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            heroMove.currentMoveSpeed = 0f;
            isAttacking = true;
            if (attackAnimationNumber != 2)
            {
                attackAnimationNumber++;
            }
            else attackAnimationNumber = 1;
            heroAttackAreaCollider.enabled = true;
            heroAnimator.Play("attack_" + attackAnimationNumber);
        }
    }

    private void StopAttacking() // вызывается в конце анимации атаки (attack_1 и attack_2)
    {
        isAttacking = false;
        heroAttackAreaCollider.enabled = false;
        heroMove.currentMoveSpeed = heroMove.MoveSpeed;
    }


}
