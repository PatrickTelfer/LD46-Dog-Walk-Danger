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
        LavaTrigger.OnDogInLava += Lava_OnDogInLava;
    }

    void Player_OnLookAtDog(string error)
    {
        playRandomSoundEffect();
    }

    void Lava_OnDogInLava(string error)
    {
        playRandomSoundEffect();
    }

    private void OnDestroy()
    {
        PlayerController.onLookAtDog -= Player_OnLookAtDog;
        LavaTrigger.OnDogInLava -= Lava_OnDogInLava;
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
