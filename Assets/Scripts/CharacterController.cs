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
        if(Input.GetKeyDown(KeyCode.Space))
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
    }
}
