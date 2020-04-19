using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerSettings.mouseSensitivity > 0)
        {
            mouseSensitivity = PlayerSettings.mouseSensitivity;
        } else
        {
            mouseSensitivity = 100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * PlayerSettings.mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * PlayerSettings.mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);



    }
}
