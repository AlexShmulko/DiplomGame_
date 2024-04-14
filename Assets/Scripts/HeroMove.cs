using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroMove : MonoBehaviour
{

    private float SPEED;

    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D playerCollider;

    public float deshLenght = 3f;
    public float jumpLenght = 5f;
    private float defaultObstacleCheckPosition;
    private string groundType;

    [SerializeField] private bool onPlatform = false;
    [SerializeField] private float step = 0f;
    [SerializeField] private Vector3 target = Vector3.zero;

    private float dirX = 0f;
    private float dirY = 0f;
    private float currentDirX = 0f; 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Collider2D attackArea;
    [SerializeField] private Collider2D obstacleCheck;
    [SerializeField] private Tilemap platformsTilemap;

    HeroStats stats;

    private enum MovementState
    {
        idle,
        run,
        jump,
        fall
    }
    MovementState state;

    int attackAnimation = 1;
    bool isAttacking = false;
    bool isDashStarting = false;
    bool isDashFinishing = false;
    bool isJumpStarting = false;
    bool isJumpFinishing = false;
    bool isFalling = false;
    bool isFlying = false;

    private void Start()
    {

        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
        attackArea.enabled = false;
        stats = gameObject.GetComponent<HeroStats>();
        SPEED = moveSpeed;
        defaultObstacleCheckPosition = Math.Abs(gameObject.transform.Find("ObstacleCheck").transform.position.x - gameObject.transform.position.x);

        groundType = gameObject.GetComponentInChildren<GroundCheck>().groundType;
        isFalling = gameObject.GetComponentInChildren<GroundCheck>().isFalling;
        anim.SetBool("isFalling", isFalling);
    }


    private void Update()
    {
        //Debug.Log(isFalling);
        isFalling = gameObject.GetComponentInChildren<GroundCheck>().isFalling;
        anim.SetBool("isFalling", isFalling);

        groundType = gameObject.GetComponentInChildren<GroundCheck>().groundType;

        deshLenght = gameObject.GetComponentInChildren<ObstacleCheck>().heroDeshLenght;
        jumpLenght = gameObject.GetComponentInChildren<ObstacleCheckTop>().heroJumpLenght;

        if (isAttacking)
        {
            moveSpeed = 0f;
            attackArea.enabled = true;
        }

        if (stats.isHealing)
        {
            moveSpeed = 0f;
            Input.ResetInputAxes();
        }

        if(!isAttacking && !stats.isHealing && !isDashStarting && !isDashFinishing && !isJumpStarting && !isFalling && !isFlying && !isJumpFinishing)
        {
            moveSpeed = SPEED;
            attackArea.enabled = false;
        }

        if (isFalling)
        {
            moveSpeed = SPEED;
        }

        if (isFlying || isJumpFinishing)
        {
            moveSpeed = SPEED;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        if(dirX != 0)
        {
            currentDirX = dirX;
        }
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        UpdateAnimation();
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack_" + attackAnimation))
        {
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
        }
        else 
        {
            isAttacking = false;
            anim.SetBool("isAttacking", isAttacking);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && dirX != 0)
        {
            Debug.Log(dirX);
            isDashStarting = true;
            anim.SetBool("isDashStarting", isDashStarting);
            //player.velocity = new Vector2(3f*currentDirX , player.velocity.y);
            //player.AddForce(new Vector2(-5f, 0));
            moveSpeed = 0f;
        }

        if (isDashFinishing)
        {
            player.AddForce(new Vector2(currentDirX * 50f, 0));
        }
        if (isDashStarting)
        {
            player.AddForce(new Vector2(currentDirX * 20f, 0));
        }

        //if (isJumpFinishing)
        //{
        //    player.gravityScale = 0.1f;
        //}
        //else player.gravityScale = 1f;

        if (Input.GetButtonDown("Jump") && !Input.GetKeyDown(KeyCode.S))
        {
            isJumpStarting = true;
            anim.SetBool("isJumpStarting", isJumpStarting);
            moveSpeed = 0f;
        }

        if (Input.GetKeyDown(KeyCode.S) && groundType == "Platform")
        {
            platformsTilemap.GetComponentInChildren<CompositeCollider2D>().isTrigger = true;
            Invoke(nameof(UpdatePlatformsCollider), 3f);
            Debug.Log("IOP");
        }
    }

    private void UpdatePlatformsCollider()
    {
        platformsTilemap.GetComponentInChildren<CompositeCollider2D>().isTrigger = false;
    }

    private void JumpStart()
    {
        playerCollider.offset = new Vector2(0.8f * currentDirX, playerCollider.offset.y);
        moveSpeed = 3f;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + jumpLenght);
        isJumpStarting = false;
        anim.SetBool("isJumpStarting", isJumpStarting);
        isJumpFinishing = true;
        anim.SetBool("isJumpFinishing", isJumpFinishing);
        //player.gravityScale = 0.01f;
    }

    private void JumpFinish()
    {
        isJumpFinishing = false;
        anim.SetBool("isJumpFinishing", isJumpFinishing);
        //isFlying = true;
        //anim.SetBool("isFlying", isFlying);
    }

    private void FlyFinish()
    {
        isFlying = false;
        anim.SetBool("isFlying", isFlying);
        if (!isDashStarting)
        {
            player.gravityScale = 1f;
        }
    }

    private void AirDashPause()
    {
        player.gravityScale = 0.01f;
        Debug.Log("#");
    }

    private void DashSatrt()
    {
        isJumpFinishing = false;
        anim.SetBool("isJumpFinishing", isJumpFinishing);
        //gameObject.SetActive(false);
        Debug.Log(dirX);
        gameObject.transform.position = new Vector2(transform.position.x + deshLenght * currentDirX, transform.position.y);
        isDashStarting = false;
        anim.SetBool("isDashStarting", isDashStarting);
        isDashFinishing = true;
        anim.SetBool("isDashFinishing", isDashFinishing);
    }

    private void DashFinish()
    {
        isDashFinishing = false;
        anim.SetBool("isDashFinishing", isDashFinishing);
        player.gravityScale = 1f;
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
            isJumpFinishing = false;
            anim.SetBool("isJumpFinishing", isJumpFinishing);

            if (attackAnimation < 2)
            {
                attackAnimation++;
            }
            else attackAnimation = 1;
            
            anim.Play("attack_" + attackAnimation);
        }
    }

    private void UpdateAnimation()
    {
        state = MovementState.idle;

        if (dirX > 0f && !isAttacking)
        {
            state = MovementState.run;
            sprite.flipX = false;
            attackArea.transform.position = new Vector2(player.position.x + 0.7f, attackArea.transform.position.y);
            attackArea.transform.rotation = Quaternion.Euler(0, 0, 0);
            obstacleCheck.transform.position = new Vector2(gameObject.transform.position.x + defaultObstacleCheckPosition, obstacleCheck.transform.position.y);
            playerCollider.offset = new Vector2(-0.2f, playerCollider.offset.y);
            if (isFalling)
            {
                playerCollider.offset = new Vector2(0.8f * currentDirX, playerCollider.offset.y);
            }
        }
        else if (dirX < 0f && !isAttacking)
        {
            state = MovementState.run;
            sprite.flipX = true;
            attackArea.transform.position = new Vector2(player.position.x - 0.7f, attackArea.transform.position.y);
            attackArea.transform.rotation = Quaternion.Euler(0,180,0);
            obstacleCheck.transform.position = new Vector2(gameObject.transform.position.x - defaultObstacleCheckPosition, obstacleCheck.transform.position.y);
            playerCollider.offset = new Vector2(0.2f, playerCollider.offset.y);
            if (isFalling)
            {
                playerCollider.offset = new Vector2(0.8f * currentDirX, playerCollider.offset.y);
            }
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

}