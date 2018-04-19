using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector2 bulletPos;
    public Vector3 turretPos;
    public float angle;
    //public GameObject player;
    public float delay = 0.0f;
    public float weaponSpeed = 0.0f;
    public NewBehaviourScript player;
    private Rigidbody2D myrigidbody2d;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<NewBehaviourScript>();
        myrigidbody2d = GetComponent<Rigidbody2D>();
        if(player.transform.position.x < transform.position.x)
        {
            speed = -speed;
        }
        turretPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 relativePos = target.transform.position - transform.position;
        //angle = Vector3.Angle(target.transform.position, turretPos);
        myrigidbody2d.velocity = new Vector2(speed, myrigidbody2d.velocity.y);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
        Destroy(gameObject, 3.0f);



    }
}
 

