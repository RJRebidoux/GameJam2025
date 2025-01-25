using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GoalBubble : MonoBehaviour
{
    private float savedGrav;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {


                playerRb.velocity = new Vector2(0, 0);

                playerRb.gravityScale = 0f;



            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            savedGrav = playerRb.gravityScale;

            playerRb.transform.parent = transform;
            playerRb.velocity = Vector2.zero;
            playerRb.gravityScale = 0f;

            playerRb.transform.localPosition = Vector3.Lerp(playerRb.transform.localPosition, Vector3.zero, 1f);

        }
    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
//        if (playerRb != null)
//        {
//
//
//            playerRb.transform.parent = null;
//
//
//            playerRb.gravityScale = savedGrav;
//
//
//
//        }
//    }
}
