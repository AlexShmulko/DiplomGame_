using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public PolygonCollider2D enemyAttackAreaCollider;

    public GameObject HeroObject;

    public AttackState attackState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
        enemyAttackAreaCollider.enabled = true;
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
        enemyAttackAreaCollider.enabled = false;
    }
}
/*
public class CopyOfAnimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}*/
