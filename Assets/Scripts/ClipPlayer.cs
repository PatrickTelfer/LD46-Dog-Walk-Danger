using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    AudioSource source;
    public AudioClip mainclip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (mainclip.name == "throwsound")
        {
            PlayerController.onThrowTreat += Player_OnThrowTreat;
        } else if (mainclip.name == "jingle")
        {
            Goal.onFinishLevel += Goal_OnFinishLevel;
        }
    }

    void Goal_OnFinishLevel(string error)
    {
        source.clip = mainclip;
        source.Play();
    }

    void Player_OnThrowTreat(Treat t)
    {
        source.clip = mainclip;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
