using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBig : MonoBehaviour
{
    //Hace a mario grande cuando lo toca
   private void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.CompareTag("Player")) 
       {
            Debug.Log("Mario agarró la seta!");
            Mario mario = collision.gameObject.GetComponent<Mario>();
            mario.Grow();
            Destroy(gameObject); 
        }
    }

}
