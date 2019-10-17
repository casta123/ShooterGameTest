using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacteStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_life = 100;
    public int current_life = 100;

    public UnityEvent m_onDead;

    public void TakeDamage (int damage) {
        current_life -= damage;
        if (current_life < 0) {
            m_onDead.Invoke();
        }
    }
}
