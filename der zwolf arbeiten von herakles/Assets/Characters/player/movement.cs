using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float speed = 15f;
    private float jumpSpeed = 15f;
    private float direction;
   
    private Rigidbody2D player;
    public Animator animator;
    
    public LayerMask ground;
    private bool isgrounded;
    public Transform feetPos;

    private bool isFacingRight = true; 

    private float y-Velocity;
    private bool isFalling; 


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(direction));
        
        isgrounded = Physics2D.OverlapCircle(feetPos.position, 0.3f, ground);

        CheckMovementDirection();

        private void CheckMovementDirection()
        {
            if (isFacingRight && direction < 0)
            {
                Flip();
            }
            else if (!isFacingRight && direction > 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            transform.rotate(0.0f, 180.0f, 0.0f);
        }
        
        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (isgrounded && Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if (isgrounded)
        {
            animator.SetBool("isGrounded", true);
            animator.SetFloat("y-Velocity", 0);
        }

        if (!isgrounded)
        {
            animator.SetBool("isGrounded", false);
            animator.SetFloat("y-Velocity", 1 * Mathf.Sign(player.velocity.y));
        }
    }
}
