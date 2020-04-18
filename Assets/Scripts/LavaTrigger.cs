using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag != "treat" && other.gameObject.tag != "Ground")
        {
            GameController.ResetLevel();
        }
    }
}
