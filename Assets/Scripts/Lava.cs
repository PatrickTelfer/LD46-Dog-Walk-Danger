using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lava : MonoBehaviour
{
    [Range(0, 0.05f)]
    public float lavaRiseSpeed;
    Text lavaText;

    private void Start()
    {
        lavaText = GameObject.FindGameObjectWithTag("hud").GetComponentInChildren<Text>();
        Debug.Log(lavaText);
    }
    private void Update()
    {
        Transform dog = FindObjectOfType<DogMove>().transform;
        float distanceToDog = dog.position.y - transform.position.y;

        lavaText.text = "Lava distance: " + Mathf.Floor(distanceToDog);
        if (GameController.paused == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + lavaRiseSpeed, transform.position.z);
        }
    }
}
