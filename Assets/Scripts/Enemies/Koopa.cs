using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Koopa : MonoBehaviour, IEnemy
{
    private KoopaStatus status;
    private Animator animator;
    private AutoMove autoMove;

    private Coroutine sleepCoroutine;

    [SerializeField]
    private GameObject points;

    private bool isDead;

    public bool IsDead() { 
        return this.isDead; 
    }

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.autoMove = GetComponent<AutoMove>();
        this.status = KoopaStatus.Walk;
    }

    IEnumerator Sleep() 
    { 
        this.isDead = true;
        this.status = KoopaStatus.Sleep;

        this.animator.SetBool("IsSleep", true);
        autoMove.enabled = false;
        yield return new WaitForSeconds(3f);

        this.animator.SetBool("IsSleep", false);

        autoMove.enabled = true;

        this.status = KoopaStatus.Walk;
        this.isDead = false;


    }

    public void TakeDamage(Collision2D collision)
    {
       
        switch (this.status) { 
            case KoopaStatus.Walk:
               this.sleepCoroutine = StartCoroutine(Sleep()); 
                break;
            case KoopaStatus.Sleep:
                this.Slide(collision);
               break;
           case KoopaStatus.Slide:
              this.StopKoopa();
               break;


       }
   }


   
    private void StopKoopa()
    {
        this.isDead = true;
        autoMove.enabled = false;
        this.status = KoopaStatus.Sleep;
    }

    private void Slide(Collision2D collision)
    {
       this.status = KoopaStatus.Slide;
        StopCoroutine(this.sleepCoroutine);
        var pointCollision = collision.GetContact(0).point;
        var center = transform.position;
        float velocity;

        if (pointCollision.x > center.x)
        {
            velocity = -5f;
        }
        else {
            velocity = 5f;
        }

        this.autoMove.ChangeVelocity(velocity);
        this.autoMove.enabled = true;

        //StartCoroutine(this.DisabledDead());
    }
}
public enum KoopaStatus
{
    Walk,
    Sleep,
    Slide
}
