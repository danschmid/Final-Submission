using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public float walkSpeed = 0.1f;
    float wallLeft = 0.0f;
    float wallRight = 5.0f;
    float walkingDirection = 1.0f;
    Vector2 Walk;
    public Rigidbody2D rb;
    public Animator myAnim;
    bool facingRight;
    public Transform wallCheck;
    public LayerMask wallLayer;

    //jump variables
    bool grounded = false;
    float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    bool touchingWall = false;
    public float jumpHeight;



    void Start()
    {
        wallLeft = transform.position.x - 0.5f;
        wallRight = transform.position.x + 0.5f;

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            rb.AddForce(new Vector2(0, jumpHeight));
        }*/

        Walk.x = walkingDirection * walkSpeed;
        if (transform.position.x >= wallRight && ((!grounded && transform.position.x >= 0) || (touchingWall && transform.position.x >= 0)))
        {
            walkingDirection = -1.0f;
            flip();
        }
        else if (transform.position.x <= wallLeft && ((!grounded && transform.position.x < 0) || (touchingWall && transform.position.x < 0)))
        {
            walkingDirection = 1.0f;
            flip();
        }
        transform.Translate(Walk);
    }

    void FixedUpdate()
    {

        //check if we are grounded, if no then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        touchingWall = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.1f, 1.25f), 0f, wallLayer);

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
