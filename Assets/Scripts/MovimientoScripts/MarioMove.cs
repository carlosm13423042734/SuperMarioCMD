using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMove : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private LayerMask ground;

    public bool isGrounded = false;

    public Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPlayer();
    }

    private void MovimientoPlayer()
    {
        float direccionMovimiento = Input.GetAxisRaw("Horizontal");
        float posicionActualX = this.transform.position.x;
        float nuevaPosicionX = direccionMovimiento * this.velocity * Time.deltaTime + posicionActualX;
        this.transform.position = new Vector2(nuevaPosicionX, this.transform.position.y);
        //var accelerationForce = new Vector2(this.direction * this.acceleration, 0);
        //if ((this.direction != 0 && Math.Sign(this.direction) != Mathf.Sign(this.gameObject.velocity.x)) || this.)
        //    accelerationForce = new Vector2(this.direction * this.deceleration, 0);
    }

    private void Salto()
    {
        if (Input.GetButton("Jump"))
        {
            rig.AddForce(Vector2.up * jumpForce);
        }
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

    private void FixedUpdate()
    {
        this.isGrounded = checkGrounded();
        if (this.isGrounded)
        {
            Salto();
        }
    }
}



