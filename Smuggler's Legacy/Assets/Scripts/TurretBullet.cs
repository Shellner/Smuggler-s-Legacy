using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public Transform target;
    public Vector2 bulletPos;
    public Vector3 turretPos;
    public float angle;

    // Use this for initialization
    void Start()
    {
        turretPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = target.position - transform.position;
        angle = Vector3.Angle(target.position, turretPos);

        GetComponent<Rigidbody2D>().velocity = new Vector2(10, 20);
        Destroy(gameObject, 3.0f);

        

    }
}
    
