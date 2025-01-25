using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGum : Bubble
{
    //float bubbleTime = 4;
    public float bigBounce = 10;
    public float expandSize = 2;
    public float expandSpeed = 2;

    private bool actived = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

                Destroy(gameObject, GetComponent<Bubble>().bubbleTime);
            }

        }
    }
}
