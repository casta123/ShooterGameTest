using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletsPool pool;
    // Start is called before the first frame update
    public int damage = 10;

    public characterType target;

    public void ReturnToPool() {
        if (pool) {
            pool.ReturnToPool(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (target == characterType.PLAYER) {
            if (other.tag == "Player") {
                CharacteStats charStats = other.GetComponent<CharacteStats>();
                charStats.TakeDamage(damage);
                ReturnToPool();
            }
            
        }
        if (target == characterType.ENEMY) {
            if (other.tag == "Enemy") {
                CharacteStats charStats = other.GetComponent<CharacteStats>();
                charStats.TakeDamage(damage);
                ReturnToPool();
            }
        }

        if (other.tag == "Enviroment" || other.tag == "Enemy") {
            ReturnToPool();
        }
    }

}
