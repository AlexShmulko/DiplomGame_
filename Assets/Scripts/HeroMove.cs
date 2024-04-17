using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroMove : MonoBehaviour
{
    // Константы +
    public float MoveSpeed = 5f;

    private Rigidbody2D rbHero;
    private SpriteRenderer srHero;
    private Animator heroAnimator;
    private BoxCollider2D heroCollider;

    private HeroStats heroStats;

    public float deshLenght = 3f;
    public float jumpLenght = 5f;
    private float defaultObstacleCheckPosition;
    private string groundType;

    [SerializeField] private bool onPlatform = false;

    
    //+
    public float currentMoveSpeed;
    private float currentDirX = 0f;



    [SerializeField] private Collider2D playerAttackArea;
    [SerializeField] private Collider2D obstacleCheck;
    [SerializeField] private Tilemap platformsTilemap;


    bool isFalling = false;
    bool isDashing = false;
    bool isRuning = false;  
    bool isJumping = false;  


    private void Start()
    {
        currentMoveSpeed = MoveSpeed;

        rbHero = GetComponent<Rigidbody2D>();
        srHero = GetComponent<SpriteRenderer>();
        heroAnimator = GetComponent<Animator>();
        heroCollider = GetComponent<BoxCollider2D>();

        heroStats = GetComponent<HeroStats>();

        defaultObstacleCheckPosition = Math.Abs(gameObject.transform.Find("ObstacleCheck").transform.position.x - gameObject.transform.position.x);

        groundType = gameObject.GetComponentInChildren<GroundCheck>().groundType;
    }

    public void Move(float dirX)
    {
        if (dirX != 0f) currentDirX = dirX;
        rbHero.velocity = new Vector2(dirX * currentMoveSpeed, rbHero.velocity.y);
        if (dirX > 0f)
        {
            isRuning = true;
            srHero.flipX = false;
            playerAttackArea.transform.position = new Vector2(rbHero.position.x + 0.7f, playerAttackArea.transform.position.y);
            playerAttackArea.transform.rotation = Quaternion.Euler(0, 0, 0);
            obstacleCheck.transform.position = new Vector2(gameObject.transform.position.x + defaultObstacleCheckPosition, obstacleCheck.transform.position.y);
        }
        else if (dirX < 0f)
        {
            isRuning = true;
            srHero.flipX = true;
            playerAttackArea.transform.position = new Vector2(rbHero.position.x - 0.7f, playerAttackArea.transform.position.y);
            playerAttackArea.transform.rotation = Quaternion.Euler(0, 180, 0);
            obstacleCheck.transform.position = new Vector2(gameObject.transform.position.x - defaultObstacleCheckPosition, obstacleCheck.transform.position.y);
        }else isRuning = false;
        heroAnimator.SetBool("isRuning", isRuning);
    }

    public void Dash()
    {
        isDashing = true;
        heroAnimator.Play("dash");
        currentMoveSpeed = 0f;
    }

    private void StopDash()
    {
        isDashing = false;
        currentMoveSpeed = MoveSpeed;
    }

    private void teleportationInDash()
    {
        transform.position = new Vector2(transform.position.x + currentDirX * heroStats.dashLength, transform.position.y);
    }

    public void Jump()
    {
        isJumping = true;
        heroAnimator.Play("jump");
    }

    private void StopJump()
    {
        isJumping = false;
    }

    private void teleportationInJump()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + heroStats.jumpHeight);
    }

    public void Fall(bool onGround)
    {
        if (!onGround) heroAnimator.SetBool("isFalling", true);
        if(onGround) heroAnimator.SetBool("isFalling", false);
    }

    public void FallFromPlatform(string groundType, GameObject ground)
    {

        Collider2D groundCollider = ground.GetComponent<Collider2D>();
        if(groundType == "SoftGround")
        {
            groundCollider.isTrigger = true;
            StartCoroutine(RestorGroundCor(groundCollider));
        }

    }

    IEnumerator RestorGroundCor(Collider2D groundCollider)
    {
        yield return new WaitForSeconds(3f);
        groundCollider.isTrigger = false;
    }

}