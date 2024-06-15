using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class E3_ChargeState : ChargeState
{
    private Enemy3 enemy;

    [SerializeField]
    private D_Entity entityData;

    public Vector2 playerPosition;
    bool targetSet = false;

    public E3_ChargeState(Entity entity, StateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.entity = entity;
        this.entityData = entity.entityData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        /*isChargeTimeOver = false;

        Collider2D collider = Physics2D.OverlapCircle(entity.aliveGO.transform.position, entityData.maxAgroDistance, entityData.whatIsPlayer);
        if (collider != null)
        {
            playerPosition = collider.transform.position;
            targetSet = true;
            Debug.Log(targetSet);
        }*/
           
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        /*if (targetSet)
        {
            enemy.transform.position = Vector2.MoveTowards(entity.aliveGO.transform.position, playerPosition, stateData.chargeSpeed * Time.deltaTime);

            if(isChargeTimeOver)
            { 
                targetSet = false;
                Debug.Log(targetSet);
            }
        }*/

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
