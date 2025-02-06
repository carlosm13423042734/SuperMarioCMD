using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour, IEnemy
{
    private Animator animator;
    private Collider2D collider;
    private AutoMove autoMoveScript; 
    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        autoMoveScript = GetComponent<AutoMove>();
    }

    public void TakeDamage()
    {
        StartCoroutine(StompedCoroutine());
    }

    private IEnumerator StompedCoroutine()
    {
        animator.SetTrigger("isDead"); 
        collider.enabled = false;         
        autoMoveScript.enabled = false; 

        yield return new WaitForSeconds(2f);

        Destroy(gameObject); 
    }
}
