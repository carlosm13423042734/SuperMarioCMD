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
    private float aceleration;
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
    }

    private void Salto() {
        if (Input.GetButton("Jump")) { 
            rig.AddForce(Vector2.up * jumpForce);
        }
    }

    private bool checkGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 0.6f, ground);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * 0.6f);
    }

    private void FixedUpdate()
    {
        this.isGrounded = checkGrounded();
        if (this.isGrounded) { 
            Salto();
        }
    }
}
