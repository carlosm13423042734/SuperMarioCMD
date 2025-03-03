using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedDerecha : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    //Cuando entra en contacto con un enemigo, activa el autoMove
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            var enemyScript = collision.gameObject.GetComponent<IEnemy>();
            if (enemyScript != null)
            {
                var autoMove = collision.gameObject.GetComponent<AutoMove>();
                if (autoMove != null)
                {
                    autoMove.enabled = true; // Activa el movimiento del enemigo
                }
            }
        }
    }
}
