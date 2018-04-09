using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public GameObject instance;
    public float velocityX = 1.2f;
    public float velocityY = 2.0f;
    public GameObject bullet;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    public float nextFire = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * velocityX;

        if (Input.GetKey("w"))
        {
            transform.position += (Vector3.up * velocityY * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.position += (Vector3.down * velocityY * Time.deltaTime);
        }

        if (Input.GetKey("h") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }

    }
    void fire(){
        bulletPos = transform.position;
        bulletPos += new Vector2(1.2f, 0.0f);
         instance = Instantiate(bullet, bulletPos, Quaternion.identity)as GameObject;
        Destroy(instance, 3.0f);
    }
}
