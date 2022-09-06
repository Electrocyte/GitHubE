using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody2D;
    Animator animator;
    CapsuleCollider2D capsuleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run(); 
        FlipSprite();
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            animator.SetBool("isRunning", true);
        } 
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // takes its name from the animator with same name
    void OnJump(InputValue value) {
        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            return;
        }
        
        if (value.isPressed) {
            myRigidbody2D.velocity += new Vector2(0f, jumpSpeed);
        }
    }
}
