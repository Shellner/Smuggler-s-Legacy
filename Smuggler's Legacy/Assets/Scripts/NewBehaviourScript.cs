using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private GameObject player;
    private AudioSource playerAudioSource;

    public float velocityX = 2.0f;
    public float velocityY = 5.0f;

    public Vector3 playerPos;
    public GameObject bullet;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    public float nextFire = 0;
    public float health = 100;
    public float fullHealth;
    public float lives = 3;
    public AudioClip PowerupSound;
    public Transform RespawnPoint;

    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        fullHealth = health;
    }

    void Update()
    {

        playerPos = transform.position += Vector3.right * Time.deltaTime * velocityX;

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

        if (Input.GetKey("d"))
        {
            transform.position += ((Vector3.right * 8) * velocityX * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            transform.position += (Vector3.left * (velocityX * 8) * Time.deltaTime);
        }

    }
    public void fire()
    {
        bulletPos = playerPos;
        bulletPos += new Vector2(1.6f, 0.0f);
        Instantiate(bullet, bulletPos, Quaternion.identity);

    }

    public void Harm(float dmg)
    {
        // make the player blink
        health -= dmg;

        if (health < 1)
        {
            // play animation of destroyed ship
            lives--;
            health = 1;
            StartCoroutine(RespawnTime(3));
        }
    }

    IEnumerator RespawnTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (lives == 0)
        {
            // show a game over menu
        }
        else
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = RespawnPoint.position;
        health = fullHealth;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            other.gameObject.SetActive(false);
            playerAudioSource.pitch = Random.Range(0.5f, 1.5f);
            playerAudioSource.PlayOneShot(PowerupSound, 0.5f);
            health += 50;
        }
    }
}
