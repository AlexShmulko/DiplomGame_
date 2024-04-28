using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroMove : MonoBehaviour
{
    // Константы +
    public float MoveSpeed = 5f;

    private SaveManager saveManager;
    private HeroStates heroStates;
    private Animator heroAnimator;
    private Rigidbody2D rbHero;


    //+
    private float currentMoveSpeed = 0f;
    private float currentDashSpeed = 0f;
    private float currentJumpForce = 0f;


    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        heroStates = GetComponent<HeroStates>();
        heroAnimator = GetComponent<Animator>();
        rbHero = GetComponent<Rigidbody2D>();

        currentMoveSpeed = MoveSpeed;
    }



    private void FixedUpdate()
    {
        if (heroStates.isDashing)
        {
            rbHero.velocity = transform.right * currentDashSpeed;
        }

        if (heroStates.isJumping)
        {
            rbHero.velocity = new Vector2(rbHero.velocity.x, currentJumpForce);
        }
    }

    public void Move(float dirX)
    {
        rbHero.velocity = new Vector2(dirX * currentMoveSpeed, rbHero.velocity.y);
        if (dirX > 0)
        {
            heroStates.isRunning = true;
            transform.eulerAngles = new Vector2(transform.rotation.x, 0);
        }
        else if (dirX < 0)
        {
            heroStates.isRunning = true;
            transform.eulerAngles = new Vector2(transform.rotation.x, 180);
        }
        else heroStates.isRunning = false;
        heroAnimator.SetBool("isRuning", heroStates.isRunning);
    }

    public void Dash()
    {
        currentDashSpeed = 2f;
        heroStates.isDashing = true;
        heroAnimator.Play("dash");
    }

    private void StopDash()
    {
        heroStates.isDashing = false;
    }

    public void UpDashForce()
    {
        currentDashSpeed = saveManager.dashSpeed;
    }

    public void DownDashForce()
    {
        currentDashSpeed = 2f;
    }


    public void Jump()
    {
        currentMoveSpeed = 3f;
        currentJumpForce = 0f;
        heroStates.isJumping = true;
        heroAnimator.Play("jump");
    }

    private void StopJump()
    {
        currentMoveSpeed = MoveSpeed;
        heroStates.isJumping = false;
    }

    public void UpJumpForce()
    {
        currentJumpForce = saveManager.jumpForce;
    }

    public void DownJumpForce()
    {
        currentJumpForce = 2f;
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