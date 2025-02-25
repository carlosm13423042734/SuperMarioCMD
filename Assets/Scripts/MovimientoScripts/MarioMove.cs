using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMove : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private LayerMask ground;

    private Rigidbody2D rig;
    public bool isGrounded;
    private float velocity = 0f;
    private float direction = 0f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        this.isGrounded = checkGrounded();

        
    }

    private void FixedUpdate()
    {
        MoveMario();
        Salto();

    }
    private void Salto()
    {
        if (this.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    private void MoveMario()
    {
        if (direction != 0)
        {

            if (Mathf.Sign(direction) != Mathf.Sign(velocity) && Mathf.Abs(velocity) > 0.1f)
            {
                velocity = Mathf.MoveTowards(velocity, 0, deceleration * Time.fixedDeltaTime * 1.5f);
            }
            else
            {    
                velocity = Mathf.MoveTowards(velocity, direction * maxSpeed, acceleration * Time.fixedDeltaTime);
            }
        }
        else
        {
            velocity = Mathf.MoveTowards(velocity, 0, deceleration * Time.fixedDeltaTime);
        }

        rig.velocity = new Vector2(velocity, rig.velocity.y);

        //
    }

    private bool checkGrounded()
    {
        float halfWidth = GetComponent<Collider2D>().bounds.extents.x;
        float offsetY = 0.6f;

        Vector2 leftRayOrigin = new Vector2(this.transform.position.x - (halfWidth - 0.15f), this.transform.position.y);
        Vector2 rightRayOrigin = new Vector2(this.transform.position.x + (halfWidth - 0.15f), this.transform.position.y);

        RaycastHit2D leftHit = Physics2D.Raycast(leftRayOrigin, Vector2.down, offsetY, ground);

        RaycastHit2D rightHit = Physics2D.Raycast(rightRayOrigin, Vector2.down, offsetY, ground);

        return leftHit.collider != null || rightHit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * 0.6f);
    }
}
