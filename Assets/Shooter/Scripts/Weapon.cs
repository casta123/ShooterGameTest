using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public MeshRenderer m_laser;
    public ParticleSystem m_particleSys;
    public Transform bulletAnchor;
    public characterType owner;
    public BulletsPool _bulletsPool;
    float bulletSpeed = 1000;
    public void Shoot () {
        m_particleSys.Play();
        GameObject currentBullet = _bulletsPool.GetFromPool();
        currentBullet.GetComponent<Bullet>().target = owner == characterType.PLAYER ? characterType.ENEMY : characterType.PLAYER;
        currentBullet.transform.position =  bulletAnchor.position;
        currentBullet.transform.rotation =  bulletAnchor.rotation;

        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(currentBullet.transform.forward * bulletSpeed);
        // rb.velocity = Vector3.forward * bulletSpeed;
    }
}
