using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Si Mario cae en la KillZone, pierde una vida
        if (other.gameObject.CompareTag("Player"))
        {
            Mario mario = other.gameObject.GetComponent<Mario>();
            if (mario != null)
            {
                GameManager.Instance.KillMario();
            }
        }else{ Destroy(other.gameObject);}

        
       
    }
}
