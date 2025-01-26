using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleGum : Bubble
{
    public float bigBounce = 10;
    public float expandSize = 2;
    public float expandSpeed = 2;
    private bool actived = false;

    //sound blah
    private AudioSource soundSource;
    public AudioClip inflateSound;
    private bool soundPlayed = false;

    private Vector2 startingScale = new Vector2(0.5f, 0.5f);
    private Vector2 desiredScale;
    // Start is called before the first frame update
    void Start()
    {
        desiredScale = transform.localScale * expandSize;
        soundSource = GameObject.FindGameObjectWithTag("PrimaryAudioSource").GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        actived = false;
        soundPlayed = false;
        transform.localScale = startingScale;
    }

    // Update is called once per frame
    void Update()
    {
      if (actived)
      {
          transform.localScale = Vector2.Lerp(transform.localScale, desiredScale * expandSize, expandSpeed * Time.deltaTime);
            if (!soundPlayed)
            {
                soundSource.PlayOneShot(inflateSound, 0.5f);
                soundPlayed = true;
            }
        }
    }
  
    //This Overrides the Trigger to fix the bounce
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);

                if (!actived)
                {
                    actived = true;
                playerRb.AddForce(Vector2.up * bigBounce, ForceMode2D.Impulse);
                }
                else
                    playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

                StartCoroutine(Pop(bubbleTime));
            }
        }
    }
}