using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    [Range(0.01f, 1)]
    public float dogMoveSpeed = 0.01f;
    public bool autoWalk;
    private Transform target;
    private Treat currentTreat;
    public float smoothing;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.onThrowTreat += Player_OnThrow;
        rb = GetComponent<Rigidbody>();
    }

    private void Player_OnThrow(Treat t)
    {
        t.onHitGround += Treat_OnHitGround;
        currentTreat = t;
    }

    void Treat_OnHitGround(Transform t)
    {
        target = t;
        //StopCoroutine("moveTowards");
        //StartCoroutine("moveTowards");
        currentTreat.onHitGround -= Treat_OnHitGround;

    }

    // Update is called once per frame
    void Update()
    {
        if (autoWalk)
        {
            //transform.localPosition += transform.forward * dogMoveSpeed * Time.deltaTime;
        }
        
    }

    IEnumerator moveTowards()
    {

        while (Vector3.Distance(transform.position, target.position) > 0.5f)
        {
            
            Vector3 endroit = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * smoothing);
            Debug.Log(endroit);
            rb.MovePosition(endroit);
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 endroid = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * smoothing);
            rb.MovePosition(endroid);

            if (Vector3.Distance(transform.position, target.position) < 1f)
            {
                target = null;
            }


        }
    }
}
