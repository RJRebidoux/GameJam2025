using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBubble : Bubble
{
    public float bombTime = 3f;
    //attempting to make child, idk what im doin
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pop()
    {
        Destroy(gameObject, bombTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {


                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);


                playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                //BOOOM BOOOM
                Pop();
            }
            
        }
    }
    
    }
////   IEnumerator ExplodeTimer()
////   {
////       //if ()
////       {
////           
////           yield return new WaitForSeconds(bombTime);
////           
////           
////           
////           
////
////       }
////
////   }

