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

    private enum MovementState
    {
        idle,
        run,
        jump,
        fall
    }
    MovementState state;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        if (Input.GetButtonDown("Jump") && player.velocity.y > -.1f && player.velocity.y < .1f)
        {
            Debug.Log(player.velocity.y);
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        state = MovementState.idle;

        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
            //attackPoint.position = new Vector2(player.position.x + 0.5f, player.position.y);
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
            //attackPoint.position = new Vector2(player.position.x - 0.5f, player.position.y);
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