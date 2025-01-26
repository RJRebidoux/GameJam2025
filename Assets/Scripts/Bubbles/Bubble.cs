using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bubble : MonoBehaviour
{ 
    public float bubbleTime = 20;
    public float bounceForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);

                playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                 StartCoroutine(Pop(bubbleTime));
            }
            SceneManager.LoadScene("GoalScene");
        }
    }

    
    public IEnumerator Pop(float time)
    {
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }
    }
}

