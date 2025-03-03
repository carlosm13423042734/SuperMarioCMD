using Assets.Scripts;
<<<<<<< HEAD
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


=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour, IEnemy
{
    private Rigidbody2D rbKoopa;
    private Animator animKoopa;
    private AutoMove autoMove;

    private Coroutine sleepCoroutine;
    public KoopaStatus status;

    private bool isDead = false;

    public enum KoopaStatus
    {
        Walk,
        Sleep,
        Slide
    }

    private void Start()
    {
        rbKoopa = GetComponent<Rigidbody2D>();
        animKoopa = GetComponent<Animator>();
        autoMove = GetComponent<AutoMove>();
    }

    private void Update()
    {
        ChangeSprite();

        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    private void ChangeSprite()
    {
        if (rbKoopa.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (rbKoopa.velocity.x < 0)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }
>>>>>>> 1daa5d0 (Cambios finales)
    }

    public void TakeDamage(Collision2D collision)
    {
<<<<<<< HEAD
       
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
=======


        GameManager.Instance.AddScore();

        switch (this.status)
        {
            case KoopaStatus.Walk:
                this.sleepCoroutine = StartCoroutine(Sleep());
                break;
            case KoopaStatus.Sleep:
                this.Slide(collision);
                break;
            case KoopaStatus.Slide:
                StopKoopa();
                break;
        }
    }

    private IEnumerator Sleep()
    {
        status = KoopaStatus.Sleep;
        animKoopa.SetBool("IsSleep", true);
        autoMove.enabled = false;
        yield return new WaitForSeconds(3f);

        animKoopa.SetBool("IsSleep", false);
        autoMove.enabled = true;

        status = KoopaStatus.Walk;
>>>>>>> 1daa5d0 (Cambios finales)
    }

    private void Slide(Collision2D collision)
    {
<<<<<<< HEAD
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
=======
        if (sleepCoroutine != null) StopCoroutine(sleepCoroutine);

        float velocity = 5f; // Valor por defecto en caso de que no haya contactos

        if (collision.contactCount > 0)
        {
            var pointCollision = collision.GetContact(0).point;
            var center = transform.position;
            velocity = (pointCollision.x > center.x) ? -10f : 10f;
        }

        StartCoroutine(ActivateShell(velocity));
    }

    private IEnumerator ActivateShell(float velocity)
    {
        yield return new WaitForSeconds(0.1f);

        status = KoopaStatus.Slide;
        autoMove.enabled = true;
        autoMove.ChangeVelocity(velocity);
    }

    private void StopKoopa()
    {
        rbKoopa.velocity = Vector2.zero;
        autoMove.enabled = false;

        status = KoopaStatus.Sleep;
        sleepCoroutine = StartCoroutine(Sleep());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Mario mario = collision.gameObject.GetComponent<Mario>();
        IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();

        if (mario != null && status != KoopaStatus.Sleep)
        {
            GameManager.Instance.KillMario();
        }

        if (enemy != null && status == KoopaStatus.Slide)
        {
            enemy.TakeDamage(collision);
        }
    }

    public bool Die()
    {
        autoMove.enabled = false;
        Destroy(gameObject, 1f);
        return isDead;
    }
}
>>>>>>> 1daa5d0 (Cambios finales)
