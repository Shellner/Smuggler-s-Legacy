using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public static CanvasController canvasControllerInstance;
    public Text livesText;
    public Slider healthSlider;
    public Image Fill;
    public float playerHealth = 50f;

    private float lifeMid = 40f;
    private float lifeCritical = 10f;
    private Quaternion cameraStable;

    void Start()
    {
        canvasControllerInstance = this;
        healthSlider.wholeNumbers = true;
        healthSlider.minValue = 0f;
        healthSlider.maxValue = 100f;
    }

    void Update()
    {
        livesText.text = "x" + GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>().lives;
        healthSlider.value = playerHealth;
        if (playerHealth <= lifeCritical)
        {
            Fill.color = Color.red;
        }
        else if (playerHealth <= lifeMid)
        {
            Fill.color = Color.yellow;
        }
        else
        {
            Fill.color = Color.blue;
        }

        playerHealth--;
    }

}