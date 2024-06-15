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

        if (heroStates.isHealing || heroStates.isDrinkingMana)
        {
            Input.ResetInputAxes();
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
        currentDashSpeed = 3f;
        heroStates.isRunning = false;
        heroAnimator.SetBool("isRuning", heroStates.isRunning);
        heroStates.isDashing = true;
        heroAnimator.Play("dash");
    }

    private void StopDash()
    {
        StartCoroutine(WaitAfterMove());

    }

    public void UpDashForce()
    {
        currentDashSpeed = saveManager.dashSpeed;
    }

    public void DownDashForce()
    {
        currentDashSpeed = 3f;
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
        if (ground.TryGetComponent<Collider2D>(out Collider2D col) == true)
        {
            Collider2D groundCollider = ground.GetComponent<Collider2D>();
            if (groundType == "SoftGround")
            {
                Debug.Log("aaa!");
                groundCollider.enabled = false;
                StartCoroutine(RestorGroundCor(groundCollider));
            }
        }
    }

    IEnumerator RestorGroundCor(Collider2D groundCollider)
    {
        yield return new WaitForSeconds(1.5f);
        groundCollider.enabled = true;
    }

    IEnumerator WaitAfterMove()
    {
        yield return new WaitForSeconds(0.1f);
        heroStates.isDashing = false;
    }

}