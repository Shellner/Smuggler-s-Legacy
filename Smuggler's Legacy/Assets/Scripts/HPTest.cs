using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTest : MonoBehaviour {
    private int hp;
    public int hpreal;
    public int scoreValue;
    private CanvasController canvasController;

	// Use this for initialization
	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("CanvasController");
        if (gameControllerObject != null)
        {
            canvasController = gameControllerObject.GetComponent<CanvasController>();
        }
        if (canvasController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        hp = hpreal;
    }
	
	// Update is called once per frame
	void Update () {
        if (hp == 0)
        {
            canvasController.addScore(scoreValue);
            Debug.Log("bullet hit");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //enemy dies on contact with bullet
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= 1;
            if (hp <= 0)
                GetComponent<Animator>().Play("AsteroidExplosion", -1, 0f);
                Destroy(gameObject);
           

        }
        else if (other.gameObject.tag == "Backwall")
        {
            hp -= 100;
            if (hp <= 0)
                Destroy(gameObject);

        }
    }
    


}

