using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D playerCollider;
    //public Transform attackPoint;

    [SerializeField] private bool onPlatform = false;
    [SerializeField] private float step = 0f;
    [SerializeField] private Vector3 target = Vector3.zero;

    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private Collider2D attackArea;

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

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
        attackArea.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAttacking)
        {
            moveSpeed = 0f;
            attackArea.enabled = true;
        }
        else
        {
            moveSpeed = 3f;
            attackArea.enabled = false;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);


        if (Input.GetButtonDown("Jump") && player.velocity.y > -.1f && player.velocity.y < .1f)
        {
            Debug.Log(player.velocity.y);
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }

        UpdateAnimation();
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        //else
        //{
        //    isAttacking = false;
        //    anim.SetBool("isAttacking", isAttacking);
        //}
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
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
            //Debug.Log(isAttacking);

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
            playerCollider.offset = new Vector2(-0.2f, playerCollider.offset.y);
            //player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);
            //attackPoint.position = new Vector2(player.position.x + 0.5f, player.position.y);
        }
        else if (dirX < 0f && !isAttacking)
        {
            state = MovementState.run;
            sprite.flipX = true;
            attackArea.transform.position = new Vector2(player.position.x - 0.7f, attackArea.transform.position.y);
            attackArea.transform.rotation = Quaternion.Euler(0,180,0);
            playerCollider.offset = new Vector2(0.2f, playerCollider.offset.y);
            //player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);
        }
        else
        {
            state = MovementState.idle;
        }

        //if (player.velocity.y > .1f)
        //{
        //    state = MovementState.jump;
        //}
        //else if (player.velocity.y < -.1f)
        //{
        //    state = MovementState.fall;
        //}

        anim.SetInteger("state", (int)state);
    }

}