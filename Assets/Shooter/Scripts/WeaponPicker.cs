using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    public Weapon m_weapon;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlayerController pController = other.GetComponent<PlayerController>();
            pController.PickWeapon(m_weapon);
            gameObject.SetActive(false);
        }
    }
}
