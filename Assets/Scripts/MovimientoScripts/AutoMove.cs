using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField]
    int velocidad = 3;
    int direccion = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
=======
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle") || (collision.gameObject.layer == LayerMask.NameToLayer("Enemies")))
>>>>>>> 1daa5d0 (Cambios finales)
        {
            direccion = direccion * -1;
        }
    }
    public float ChangeVelocity(float velocity) {
        return velocity += 2;
    }
}
