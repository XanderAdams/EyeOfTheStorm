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
        // You can make this more specific by checking the tag of the ground
        if (collision.contacts[0].normal.y > 0.5f) // Makes sure we hit from the top
        {
            isTouchingGround = true;
        }
    }
}
