using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Mario : MonoBehaviour
{
    private GameObject startPosition;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private MarioMove marioMoveScript;
    private float direccion;
    void Awake()
    {
        DontDestroyOnLoad(this);

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.marioMoveScript = GetComponent<MarioMove>();
    }

    private void Update()
    {
        this.direccion = Input.GetAxisRaw("Horizontal");
    }
    public void MoveTo(Vector3 position) { 
        this.transform.position = position;
    }

    private void LateUpdate()
    {
       

        this.animator.SetFloat("VelocityX", Mathf.Abs(this.rigidbody2D.velocity.x));
        this.animator.SetFloat("VelocityY", Mathf.Abs(this.rigidbody2D.velocity.y));
        this.animator.SetBool("IsGrounded", this.marioMoveScript.isGrounded);

        if (Mathf.Sign(this.direccion) != Mathf.Sign(this.rigidbody2D.velocity.x)) {
            this.animator.SetBool("Sliding", true);
        }
        else { 
            this.animator.SetBool("Sliding", false);
        }
    }

    
}
