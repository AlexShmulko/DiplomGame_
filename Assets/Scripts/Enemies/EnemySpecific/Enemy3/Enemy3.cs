using TMPro;
using UnityEngine;

public class Enemy3 : Entity
{
    public E3_IdleState idleState {  get; private set; }
    public E3_MoveState moveState { get; private set; }
    public E3_PlayerDetectedState playerDetectedState { get; private set; } 
    public E3_ChargeState chargeState { get; private set; }
    public E3_LookForPlayerState lookForPlayerState { get; private set; }
    public E3_MeleeAttackState meleeAttackState { get; private set; }

    public int facingDirection { get; private set; }
    public int facingDirectionY {get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    public Transform playerChecks;
    [SerializeField]
    private Transform meleeAttackPosition;

    //private Vector2 velocityWorkspace;

    public override void Start()
    {
        base.Start();

        facingDirection = 1;
        facingDirectionY = 1; 

        moveState = new E3_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E3_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E3_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new E3_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E3_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E3_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override bool ChekPlayerInMaxAgroRange()
    {
        return Physics2D.OverlapCircle(playerChecks.position, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    /*public override bool CheckPlayerBehind()
    {
        return Physics2D.OverlapCircle(playerChecks.position, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }*/

    /*public override void SetVeloity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, facingDirectionY * velocity);
        rb.velocity = velocityWorkspace;
    }*/

    /*public override void Flip()
    {
        facingDirectionY *= -1;
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }*/

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
        //Gizmos.DrawWireSphere(playerChecks.position, entityData.maxAgroDistance);
    }
}
