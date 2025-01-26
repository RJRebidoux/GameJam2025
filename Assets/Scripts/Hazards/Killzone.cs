using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox_Behaviour : MonoBehaviour
{
    // References
    public Transform respawn;
    public Transform cameralocation;
    public GameObject[] bubbles;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an Enemy, That Enemy takes damage;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = respawn.position;
            cameralocation.position = new Vector3(respawn.position.x, respawn.position.y, cameralocation.position.z);
            collision.gameObject.GetComponent<PlayerController>().lives = collision.gameObject.GetComponent<PlayerController>().lives - 1;
            
            ActivateAllBubbles();
        }
    }

    private void ActivateAllBubbles()
    {
        foreach (GameObject obj in bubbles)
        {
           obj.SetActive(true);  
        }
    }
}

