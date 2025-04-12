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
        movement = (movement * 0);
        if(Input.GetAxisRaw("Horizontal")==-1&&facingRight)
        {
            Flip();
        }
        else if(Input.GetAxisRaw("Horizontal")==1&&!facingRight)
        {
            Flip();
        }

        movement.x = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        rb2D.velocity = movement;

    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        //playerText.transform.localScale *= 1;
    }
}
