using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource SFXAuidoSource;

    public AudioClip musicClip;
    public AudioClip dieClip;
    public AudioClip lootClip;
    public AudioClip uiuxClip;
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

    public void LootItem(AudioClip SFX)
    {
        SFXAuidoSource.clip = SFX;
        SFXAuidoSource.PlayOneShot(SFX);
    }
}
