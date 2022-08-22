using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClip;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int place, float volume)
    {
        audioSource.PlayOneShot(audioClip[place], volume);
    }
}
