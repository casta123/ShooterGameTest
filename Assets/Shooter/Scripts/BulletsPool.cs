using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public List<GameObject> availabeBullets;
    public List<GameObject> unavailabeBullets;

    int min_bullets = 20;
    void Start()
    {
        availabeBullets = new List<GameObject>();
        unavailabeBullets = new List<GameObject>();

        for (int i = 0; i < min_bullets; i++)
        {
            GameObject bulletCopy = GameObject.Instantiate(bulletPrefab);
            bulletCopy.GetComponent<Bullet>().pool = this;
            availabeBullets.Add(bulletCopy);
            bulletCopy.SetActive(false);
        }
    }

    public GameObject GetFromPool() {
        if (availabeBullets.Count > 0) {
            GameObject currBullet = availabeBullets[0];
            availabeBullets.Remove(currBullet);
            unavailabeBullets.Add(currBullet);
            currBullet.SetActive(true);
            return currBullet;
        } else {
            GameObject currBullet = GameObject.Instantiate(bulletPrefab);
            unavailabeBullets.Add(currBullet);
            return currBullet;
        }
    }
    
    public void ReturnToPool(GameObject bullet) {
        int bulletIdx = unavailabeBullets.IndexOf(bullet);
        if (bulletIdx >= 0) {
            GameObject currBullet = unavailabeBullets[bulletIdx];
            unavailabeBullets.Remove(currBullet);
            availabeBullets.Add(currBullet);
            currBullet.SetActive(false);
        }
    }
}
