using UnityEngine;
using System.Collections;

public class EnemyTurret : MonoBehaviour
{

    public Transform target;
    public float turretSpeed;
    public float fireRate;
    public float bulletHeight;
    public GameObject bullet;
    public float range;
    float distance;
    private float _lastShotTime = float.MinValue;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotate turret to look at player.
        Vector3 relativePos = target.position + transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos);
        rotation.y = 0;
        rotation.x = 0;
        Quaternion Realrotation = Quaternion.RotateTowards(rotation, Quaternion.identity, Time.deltaTime * turretSpeed);
        
       
      transform.rotation = Quaternion.Slerp(transform.rotation, Realrotation, Time.deltaTime * turretSpeed);
        
        // transform.LookAt(target);

        //Fire at player when in range.

        distance = Vector3.Distance(transform.position, target.position);    

        if (distance < range && Time.time > _lastShotTime + (3.0f / fireRate))
        {
            _lastShotTime = Time.time;
            //print(Time.time);
            fireBullet();
        }
    }

    void fireBullet()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y + bulletHeight, transform.position.z);
        Instantiate(bullet, position, transform.rotation);
    }
}

