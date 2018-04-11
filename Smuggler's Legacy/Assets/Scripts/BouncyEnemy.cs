using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyEnemy : MonoBehaviour
{

    public float delta = 3.0f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    public float moveSpeed = -0.09f;
    private Vector3 startPos;
    private Vector3 v;
    public int hp = 0;

    void Start()
    {
        startPos = transform.position;
        v = startPos;
    }

    void Update()
    {


        v.y = delta * Mathf.Sin(Time.time * speed);
        v.x += moveSpeed;
        transform.position = v;
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        //transform.position += Vector3.left * Time.deltaTime * 1.2f;




    }
}
    //private void OnCollisionEnter2D(Collision2D collision) //enemy dies on contact with bullet
    //{
        //if(collision.gameObject.tag == "bullet")
        //{
           // hp += 1;
         //   if (hp == 3)
       //         Destroy(gameObject);

     //   }
   // }
///}
