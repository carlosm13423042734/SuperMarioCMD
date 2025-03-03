using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform mario; 
    [SerializeField] private float smoothSpeed = 0.1f; 
    [SerializeField] private Vector2 offset;

    private float minXPosition;
    private float fixedY; // Almacena la posición Y fija

    void Start()
    {
        minXPosition = transform.position.x;
        fixedY = transform.position.y; // Guarda la posición Y inicial
    }

    void LateUpdate()
    {
        if (mario == null) return;

       //Deja la posicion y fija para que cuando caiga, no baje la camara y spawnee
        Vector3 targetPosition = new Vector3(mario.position.x + offset.x, fixedY, transform.position.z);

        if (targetPosition.x < minXPosition)
            targetPosition.x = minXPosition;
        else
            minXPosition = targetPosition.x;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
    public void SetMario(Transform marioTransform)
    {
        mario = marioTransform;
    }
}
