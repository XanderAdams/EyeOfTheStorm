using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5;
    public float jumpHeight = 5;
    public float fallSpeed = 5;
    public bool facingRight = true;
    public Vector2 movement;
    public Rigidbody2D  rb2D;
    public bool isTouchingGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rayLength = 0.1f;

        // Get the bottom center of the player's collider
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 rayOrigin = new Vector2(bounds.center.x, bounds.min.y - 0.01f);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, LayerMask.GetMask("Ground"));
        isTouchingGround = hit.collider != null;

        rb2D.velocity = movement;
    }

    void Update()
    {
        rb2D.gravityScale = fallSpeed;
        movement = rb2D.velocity;
        if(Input.GetAxisRaw("Horizontal")==-1&&facingRight)
        {
            Flip();
        }
        else if(Input.GetAxisRaw("Horizontal")==1&&!facingRight)
        {
            Flip();
        }
        if(Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            Jump();
        }

        movement.x = speed * Time.fixedDeltaTime * Input.GetAxis("Horizontal");
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump()
    {
        movement = rb2D.velocity;
        movement.y = jumpHeight;
        rb2D.velocity = movement;
        isTouchingGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Only consider ground contact if the surface is below the player
            if (contact.normal.y > 0.5f)
            {
                isTouchingGround = true;
                return; // Don't keep checking other contacts if we already found valid ground
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingGround = false;
    }
}
