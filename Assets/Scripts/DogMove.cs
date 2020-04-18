using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    public float dogMoveSpeed = 4f;
    public bool autoWalk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (autoWalk)
        {
            transform.localPosition += transform.forward * dogMoveSpeed * Time.deltaTime;
        }
    }
}
