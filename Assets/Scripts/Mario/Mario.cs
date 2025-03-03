using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
<<<<<<< HEAD
=======
using Assets.Scripts;

>>>>>>> 1daa5d0 (Cambios finales)

public class Mario : MonoBehaviour
{
    private GameObject startPosition;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private MarioMove marioMoveScript;
<<<<<<< HEAD
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
=======
    private MarioStomp marioStomp;
    private float direccion;
    private bool isSmall = true;
    public static Mario Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hacer que el objeto Mario persista entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruir duplicados
        }
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.marioMoveScript = GetComponent<MarioMove>();
        marioStomp = GetComponentInChildren<MarioStomp>(); 

    }

    private void Update()
{
    this.direccion = Input.GetAxisRaw("Horizontal");

    // Verificar si Mario está cambiando de dirección y ajustar la escala en X
    if (this.direccion > 0 && transform.localScale.x < 0)
    {
        Flip();
    }
    else if (this.direccion < 0 && transform.localScale.x > 0)
    {
        Flip();
    }
}

private void Flip()
{
    Vector3 scale = transform.localScale;
    scale.x *= -1; // Invertir la escala en el eje X
    transform.localScale = scale;
}

>>>>>>> 1daa5d0 (Cambios finales)
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

    
<<<<<<< HEAD
=======
public void PlayDeathAnimation()
{
    animator.SetBool("IsDead", true); // Activa la animación de muerte
    this.gameObject.layer = LayerMask.NameToLayer("Dead");
    marioStomp.gameObject.layer = LayerMask.NameToLayer("Dead");
    this.animator.SetInteger("Status", 0); // Cambia la animación

    rigidbody2D.velocity = Vector2.zero; // Detiene el movimiento
    rigidbody2D.AddForce(Vector2.up * 5f, ForceMode2D.Impulse); //Salto hacia arriba para la animación
    rigidbody2D.gravityScale = 2f; 
    marioMoveScript.enabled = false; 
}

public void Respawn()
{
    Debug.Log("Mario respawneando...");
    animator.SetBool("IsDead", false); 
    this.gameObject.layer = LayerMask.NameToLayer("Player");
    marioStomp.gameObject.layer = LayerMask.NameToLayer("Player");

    float leftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x; // Posición de respawn
    float respawnHeight = 0.5f; // Altura específica para respawnear

    transform.position = new Vector3(leftCameraBorder, respawnHeight, transform.position.z);
    marioMoveScript.enabled = true; // Reactivar control
}

public void Grow()
{
    if (GameManager.Instance.IsSmall) // Si Mario es pequeño
    {
        GameManager.Instance.IsSmall = false; // Ahora es grande
        this.animator.SetInteger("Status", 1); // Cambia la animación
    }
}


        
>>>>>>> 1daa5d0 (Cambios finales)
}
