using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class ChangeScene : MonoBehaviour
{
     private string sceneName = "SampleScene"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica que sea Mario
        {
            SceneManager.LoadScene(sceneName); // Carga la nueva escena
            Mario mario = FindObjectOfType<Mario>(); 
            mario.transform.position = new Vector3(0f, -2.0f, 0);
        }
    }
}
