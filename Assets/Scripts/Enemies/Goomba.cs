using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour, IEnemy
{
    private Animator animator;
    private Collider2D collider;
    private AutoMove autoMoveScript; 
<<<<<<< HEAD
=======
    private MarioMove marioMoveScript;


>>>>>>> 1daa5d0 (Cambios finales)
    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        autoMoveScript = GetComponent<AutoMove>();
<<<<<<< HEAD
    }

=======
         this.marioMoveScript = GetComponent<MarioMove>();

    }
    //Cuando ejecuta el metodo de la interfaz, comienza una corrutina la cual hace que cambie de layer, desactive el movimiento y active una animacion
>>>>>>> 1daa5d0 (Cambios finales)
    public void TakeDamage(Collision2D collision)
    {
        StartCoroutine(StompedCoroutine());
    }

    private IEnumerator StompedCoroutine()
    {
        animator.SetTrigger("isDead");
        this.gameObject.layer = LayerMask.NameToLayer("Dead");
        autoMoveScript.enabled = false; 

        yield return new WaitForSeconds(2f);

        Destroy(gameObject); 
    }
<<<<<<< HEAD
=======
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Mario mario = collision.gameObject.GetComponent<Mario>();

            if (mario != null && mario.transform.position.y <= this.transform.position.y + 0.3f)
            {
                GameManager.Instance.KillMario();
            }
        }   
    }

>>>>>>> 1daa5d0 (Cambios finales)
}
