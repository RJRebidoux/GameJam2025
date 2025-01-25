using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //sources
    private AudioSource soundSource;

    //sfx
    public AudioClip[] bounceSounds;
    public AudioClip popSound;

    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        soundSource = player.GetComponent<AudioSource>();

    }

    void Update()
    {


    }

    public void PlayRandomBounceSound()
    {
        if (bounceSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, bounceSounds.Length);
            soundSource.PlayOneShot(bounceSounds[randomIndex]);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayRandomBounceSound();
        }
    }
    private void OnDestroy()
    {
        soundSource.PlayOneShot(popSound);
    }
}
