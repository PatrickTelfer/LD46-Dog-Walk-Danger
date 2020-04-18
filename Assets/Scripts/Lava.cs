using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [Range(0, 0.05f)]
    public float lavaRiseSpeed;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + lavaRiseSpeed, transform.position.z);
    }
}
