using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAddLive : MonoBehaviour
{
    //Cuando tiene una colision con el tag player(mario) a�ade la vida con el m�todo del GameManager.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            GameManager.Instance.addLives();
            Destroy(gameObject); 
        }
    }
}
