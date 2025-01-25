using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float bounceForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                

                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);

                
                playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }

        }
    }
}

