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

    private void Start()
    {
        PlayerController.onThrowTreat += Player_OnThrowTreat;
    }

    void Player_OnThrowTreat(Treat obj)
    {
        PlayerController.onThrowTreat -= Player_OnThrowTreat;

        if (this != null)
        {
            Destroy(gameObject);
        }
             
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "player")
        {
            triggerEvent();
        }
    }
}
