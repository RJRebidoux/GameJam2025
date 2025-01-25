using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References
    Rigidbody2D rb;
    enum MovementState { idle, walking, jumping, falling}

    // Variables
    public float speed = 8f;
    public bool facingLeft;
    bool doubleJump;
    public float jumpHeight = 20f;
    public bool isGrounded;
    
    bool alive = true;

    private int lives = 3;
    // Gravity Scales
    public float light_gravityScale = 5f;
    public float fallgravityScale = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            // ---- Movement ------ 
            if (Input.GetKey(KeyCode.D))
            {
                //if (!facingLeft) 
                rb.velocity = new Vector2(speed, rb.velocity.y);
                //else if (!facingLeft) rb.velocity = new Vector2(speed, rb.velocity.y);
                if (facingLeft) Turn();

            }
            else if (Input.GetKey(KeyCode.A))
            {
                //if (facingLeft) 
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                //else if (facingLeft) rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (!facingLeft) Turn();
            }
            else
            {
                rb.velocity =
                    new Vector2(0.0f,
                        rb.velocity.y); // Note: Need to rework this so that the conveyor belt works better 
            }

            // ---- Gravity --------
            if (rb.velocity.y < 0 && !isGrounded)
            {
                //state = MovementState.falling;
                rb.gravityScale = fallgravityScale;
            }
            else
            {
                rb.gravityScale = light_gravityScale;

            }

            if (rb.velocity.y > 1.5f)
            {
                //state = MovementState.jumping;
            }

            // ------ Jumping --------
            // The longer you hold down space, the higher you go
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

                    isGrounded = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void GameEnd()
    {

    }
    void LoseLife()
    {
        lives = lives - 1;
        if (lives < 0)
        {
            GameEnd();
        }
    }

    private void GameoOver()
    {
        throw new System.NotImplementedException();
    }

    void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Bubble"))
        {
            isGrounded = true;
        }
        if (collision.CompareTag("Goal"))
        {
            isGrounded = true;
            rb.gravityScale = 0f;

        }
    }
}
