using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    public void PlaySelectedAudioClip(AudioClip audio)
    {
        source.PlayOneShot(audio);
    }
}
