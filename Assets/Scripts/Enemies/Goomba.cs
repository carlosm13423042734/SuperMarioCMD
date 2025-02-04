using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour, IEnemy
{

    public void TakeDamage() { 
        Destroy(this.gameObject, 3f);
    }
}
