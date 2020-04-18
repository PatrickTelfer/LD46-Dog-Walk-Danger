using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    public float dogMoveSpeed = 4f;
    public bool autoWalk;
    private Transform target;
    private Treat currentTreat;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.onThrowTreat += Player_OnThrow;
    }

    private void Player_OnThrow(Treat t)
    {
        t.onHitGround += Treat_OnHitGround;
        currentTreat = t;
    }

    void Treat_OnHitGround(Transform t)
    {
        target = t;
        currentTreat.onHitGround -= Treat_OnHitGround;

    }

    // Update is called once per frame
    void Update()
    {
        if (autoWalk)
        {
            transform.localPosition += transform.forward * dogMoveSpeed * Time.deltaTime;
        }
        if (target != null)
        {
            float step = dogMoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector3.Distance(transform.position, target.position) < 1f)
            {
                target = null;
            }


        }
    }
}
