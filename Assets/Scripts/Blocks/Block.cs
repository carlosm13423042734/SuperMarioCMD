using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : BlockBase
{
    [SerializeField]
    private int coins;
    public GameObject coin;
    public GameObject bloqueInvencible;

    public void Hit() { 
        base.Hit();
        Instantiate(coin,new Vector3(this.transform.position.x, this.transform.position.y + 1), Quaternion.identity);
<<<<<<< HEAD

=======
        GameManager.Instance.addCoins();
>>>>>>> 1daa5d0 (Cambios finales)
        this.coins--;
        if (coins <= 0) {
            
            Instantiate(bloqueInvencible, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
    }
}

