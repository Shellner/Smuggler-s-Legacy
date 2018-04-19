using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTest : MonoBehaviour {
    public int hp = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision) //enemy dies on contact with bullet
    {
        if (collision.gameObject.tag == "bullet")
        {
            hp -= 1;
            if (hp == 0)
                Destroy(gameObject);

        }
    }
}

