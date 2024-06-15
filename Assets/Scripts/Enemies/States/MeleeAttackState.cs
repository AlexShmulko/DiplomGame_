using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttackState stateData;

    DataManager dataManager;

    public int TakeDamage;

    public MeleeAttackState(Entity entity, StateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        TakeDamage = 0;

        dataManager = DataManager.Instance;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        // Проверяем, есть ли объект, попавший в область атаки
        Collider2D detectedObject = Physics2D.OverlapCircle(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        // Если объект был обнаружен
        if (detectedObject != null)
        {
            // Получаем ссылку на игровой объект, связанный с этим коллайдером
            GameObject other = detectedObject.gameObject;

            // Проверяем, есть ли на этом объекте компонент DamageSystem
            DamageSystem damagesys = other.GetComponent

              <DamageSystem>();

            // Если компонент DamageSystem был найден на объекте
            if (damagesys != null)
            {
                // Применяем урон
                TakeDamage = 1;
                dataManager.SetDamage(TakeDamage);
                damagesys.SecretInvoke();
            }
        }
    }
}