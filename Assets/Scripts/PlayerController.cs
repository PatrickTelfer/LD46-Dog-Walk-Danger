using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action<Treat> onThrowTreat;
    public static event Action<string> onLookAtDog;

    public Camera cam;

    public float treatLaunchSpeed = 10f;

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public GameObject treat;
    Transform treatHolder;
    public Transform treatSpawnLocation;

    Vector3 move;

    bool throwRequired = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<GameController>().ResetLevel(-1);
        }

        throwRequired = Input.GetMouseButtonDown(0);

        if (throwRequired && GameController.paused == false)
        {
            Treat currentTreatThrown = Instantiate(treat, treatHolder).GetComponent<Treat>();
            currentTreatThrown.GetComponent<Transform>().position = treatSpawnLocation.position;
            currentTreatThrown.GetComponent<Transform>().rotation = UnityEngine.Random.rotation;
            currentTreatThrown.GetComponent<Rigidbody>().AddForce((treatSpawnLocation.forward) * treatLaunchSpeed);
            onThrowTreat?.Invoke(currentTreatThrown);
        }

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Dog")
            {
                onLookAtDog?.Invoke("");
            }

            // Do something with the object that was hit by the raycast.
        }

    }

    private void Start()
    {
        treatHolder = new GameObject().transform;
        treatHolder.name = "treat holder";

    }
}
