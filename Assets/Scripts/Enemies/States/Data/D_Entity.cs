using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;

    public float minAgroDistance = 2f;
    public float maxAgroDistance = 3f;

    public float closeRangeActionDistance = 1f;

    public LayerMask whatIsGround;

    //public string playerTag = "Player";

    public LayerMask whatIsPlayer;
}