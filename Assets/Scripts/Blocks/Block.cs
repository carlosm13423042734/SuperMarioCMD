using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : BlockBase
{
    [SerializeField]
    private int coins;

    public void Hit() { 
        base.Hit();

        this.coins--;
        if (coins == 0) { 
            Destroy(this);
        }
    }
}
