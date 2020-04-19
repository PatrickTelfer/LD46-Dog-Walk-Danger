using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LavaTrigger : MonoBehaviour
{

    public static Action<string> OnDogInLava;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Dog")
        {
            Debug.Log("SUPP");
            OnDogInLava?.Invoke("");
        }

        if (other.gameObject.tag != "treat" && other.gameObject.tag != "Ground")
        {
            FindObjectOfType<GameController>().ResetLevel(-1);
        }
    }
}
