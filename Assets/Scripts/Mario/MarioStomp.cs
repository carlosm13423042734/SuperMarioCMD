using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStomp : MonoBehaviour
{

    private MarioMove marioMove;
    private KoopaStatus status;
    private void Awake()
    {
        this.marioMove = GetComponent<MarioMove>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        var colision = new Collision2D();
        var enemyScript = collider.gameObject.GetComponent<IEnemy>();
        
        if (enemyScript != null) { 
            enemyScript.TakeDamage(colision);         
           
        }
    }
}
