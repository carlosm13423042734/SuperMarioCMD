using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStomp : MonoBehaviour
{

    private MarioMove marioMove;
   
    private void Awake()
    {
        this.marioMove = GetComponent<MarioMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyScript = collision.gameObject.GetComponent<IEnemy>();
        
        if (enemyScript != null) { 
            enemyScript.TakeDamage(collision);         
           
        }
    }
}
