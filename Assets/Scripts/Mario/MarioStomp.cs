using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStomp : MonoBehaviour
{
<<<<<<< HEAD

    private MarioMove marioMove;
    private KoopaStatus status;
    private void Awake()
    {
        this.marioMove = GetComponent<MarioMove>();
    }
=======
    private Rigidbody2D rigidbody2D;
    private MarioMove marioMove;

    private void Awake()
{
    this.rigidbody2D = GetComponentInParent<Rigidbody2D>(); 
    this.marioMove = GetComponentInParent<MarioMove>(); 
}

>>>>>>> 1daa5d0 (Cambios finales)

    private void OnTriggerEnter2D(Collider2D collider)
    {

        var colision = new Collision2D();
        var enemyScript = collider.gameObject.GetComponent<IEnemy>();
        
        if (enemyScript != null) { 
            enemyScript.TakeDamage(colision);         
<<<<<<< HEAD
           
=======
            GameManager.Instance.AddScore();
            rigidbody2D.AddForce(Vector2.up * 5f, ForceMode2D.Impulse); 

>>>>>>> 1daa5d0 (Cambios finales)
        }
    }
}
