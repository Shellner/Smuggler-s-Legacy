using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject turretbullet;
    private float _lastShotTime = float.MinValue;
    private float fireRate = 1.5f;
    private float nextFire = 0;
    float distance;
    public float range;
    public Transform target;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireEnemyBullet();
        }


        distance = Vector3.Distance(transform.position, target.position);

    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null && distance < range && Time.time > _lastShotTime + (3.0f / fireRate))
        {
            GameObject bullet = (GameObject)Instantiate(turretbullet);
            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<TurretBullet>().SetDirection(direction);
        }
    }

}
