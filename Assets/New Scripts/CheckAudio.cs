using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAudio : MonoBehaviour
{
    AudioPlay audioPlay;
    public int position;
    public float volume;
    bool isTrigger;

    private void Start()
    {
        audioPlay = FindObjectOfType<AudioPlay>();
        isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (isTrigger)
            {
                audioPlay.PlayAudio(position, volume);
                isTrigger = false;
            }
        }
    }
}
