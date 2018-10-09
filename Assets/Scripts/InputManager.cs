using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public float movementSpeed;
    public float jumpForce;
    public LayerMask ground;

    public bool canJump;
    public bool canDubbleJump;

    private bool playerFalling;
    private bool playerGrounded;
    private Collider2D playerColider;
    private Rigidbody2D rb;
    private Animator animator;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerColider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        playerGrounded = Physics2D.IsTouchingLayers(playerColider, ground);


        if(Input.GetKey("right")) {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }

        if(Input.GetKey("left")) {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }

        if(rb.velocity.x > 0) { transform.localScale = new Vector3(1f, 1f, 1f); }
        else if (rb.velocity.x < 0) { transform.localScale = new Vector3(-1f, 1f, 1f); }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("up")) {
            if(playerGrounded && canJump|| canDubbleJump) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                playerGrounded = false;
            }
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if(rb.velocity.y < -0.1) {
            animator.SetBool("Falling", true);
        } else {
            animator.SetBool("Falling", false);
        }
        animator.SetBool("Grounded", playerGrounded);
    }
}
