using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float jumpForce;
    public float liftingForce;


    public bool jumped;


    public bool doubleJumped;

    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private float timestamp;
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Time.time >= timestamp)
        {
            if (jumped || doubleJumped)
            {
                jumped = false;
                doubleJumped = false;
            }
            timestamp = Time.time + 1f;
        }

        if (Input.GetMouseButton(0))
        {
            if (!jumped)
            {
                rb.velocity = new Vector2(0f, jumpForce);
                jumped = true;
            }
            else if (!doubleJumped)
            {
                rb.velocity = new Vector2(0f, jumpForce);
                doubleJumped = true;
            }
        }

        if (Input.GetMouseButton(0) && rb.velocity.y <= 0)
        {
            rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime));
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(collider.bounds.center,
         collider.bounds.size, 0f, Vector2.down, 0.1f, whatIsGround);
         return hit.collider != null;
    }
}
