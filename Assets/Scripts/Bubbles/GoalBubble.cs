using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;


public class GoalBubble : MonoBehaviour
{
    private float savedGrav;

    public string targetScene;
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

            SceneManager.LoadScene("GoalScene");

        }
    }



    void LoadScene(string target)
    {
        SceneManager.LoadScene(target);
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
