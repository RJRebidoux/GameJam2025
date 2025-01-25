using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleGum : Bubble
{
    public float bubbleTime = 4;

    public float expandSize = 2;
    public float expandSpeed = 2;
    private bool actived = false;

    private Vector2 desiredScale;
    // Start is called before the first frame update
    void Start()
    {
       desiredScale = transform.localScale * expandSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (actived)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, desiredScale * expandSize, expandSpeed * Time.deltaTime);
        }
    }
        

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {


                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);


                playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                if (!actived)
                {
                    actived = true;
                }
                
                Destroy(gameObject, bubbleTime);
            }

        }
    }
    //This Overrides the Trigger to fix the bounce
    void OnTriggerEnter2D(Collider2D other)
    {

    }


}
