﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {


    public float velocityX = 5.0f;
    public float velocityY = 0;
     public float timer;
    public GameObject bullet;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {


        rb.velocity = new Vector2(velocityX, velocityY);
        
       // Destroy(gameObject, 3f);
	}

}
