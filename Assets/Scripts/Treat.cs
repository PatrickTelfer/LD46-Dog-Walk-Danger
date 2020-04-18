using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Treat : MonoBehaviour
{
    public event Action<Transform> onHitGround;
    public bool hasTriggeredEvent = false;

    private void triggerEvent()
    {
        if(onHitGround != null)
        {
            onHitGround(transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        triggerEvent();
    }
}
