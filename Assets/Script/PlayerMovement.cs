using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Float")]
    public float speed = 5;
    public float jumpForce = 300;
    private float x;


    [Space]
    [Header("Booleans")]
    public bool isJumpUp = false; // Y軸速度>0
    public bool fall = false; //判斷是否放開跳躍鍵
    private bool jumping = false;
    private bool doubleJump = true;
    private bool canMove = true;
    private bool damage = false;
    private bool startJump = false;

    [Space]
    [Header("Object")]

    [HideInInspector]
    public Rigidbody2D rb;
    Animator animator;
    private Collision coll;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collision>();
    }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        SetJumpState();
        if (Input.GetButtonDown("Jump"))
        {
            if (coll.OnGround() || doubleJump) startJump = true;
        }

    }

    private void FixedUpdate()
    {
        Move();
        Jump();

        if (coll.OnGround()) {
            jumping = false;
            doubleJump = true;
        }

        //判斷落下
        if (rb.velocity.y < 0)
        {
            isJumpUp = false;
        }

        // 短按跳躍落下
        if (isJumpUp)
        {
            if (!Input.GetButton("Jump"))
            {
                fall = true;
            }
        }
        if (fall && rb.velocity.y <= 2.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            fall = false;
        }

    }

    void Move()
    {
        if (!canMove) return;
        float movement = x * speed;
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

  
    void Jump()
    {
        if (coll.OnGround() && (rb.velocity.y < 1 && rb.velocity.y > -1))
        {
            if (startJump)
            {
                jumping = true;
                rb.velocity = new Vector3(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * jumpForce);
                isJumpUp = true;
                startJump = false;
            }
        }
        else if (doubleJump && startJump) {
            jumping = true;
            rb.velocity = new Vector3(rb.velocity.x, 0);
            rb.AddForce(Vector3.up * jumpForce * 1f);
            isJumpUp = true;
            startJump = false;
            doubleJump = false;
        }
    }

    void SetJumpState()
    {
        if (rb.velocity.y > 1 || rb.velocity.y < -1)
        {
            jumping = true;
        }
    }
}
