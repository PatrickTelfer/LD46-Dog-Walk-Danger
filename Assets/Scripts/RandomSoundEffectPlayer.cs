using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundEffectPlayer : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    public AudioClip[] randomClips;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        PlayerController.onLookAtDog += Player_OnLookAtDog;
    }

    void Player_OnLookAtDog(string error)
    {
        playRandomSoundEffect();
    }

    private void playRandomSoundEffect()
    {
        if (randomClips.Length == 0 || source.isPlaying)
        {
            return;
        }

        int clipIndex = Random.Range(0, randomClips.Length - 1);
        AudioClip clipToPlay = randomClips[clipIndex];
        source.clip = clipToPlay;
        source.Play();
    }
}
