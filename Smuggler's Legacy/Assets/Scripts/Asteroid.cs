﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    private Vector3 v;
    public float dmg;
    public float angleX;
    public float angleY;
    public float rotationSpeed;
    // Use this for initialization
    void Start () {
        v = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        v.x += angleX;
        v.y += angleY;
       transform.position = v;
       transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<NewBehaviourScript>().Harm(dmg);
            Destroy(gameObject);
        }
    }
}
